#region Enum
public enum MemState : int
{
    Commit = 0x1000,
    Free = 0x10000,
    Reserve = 0x2000
}

[Flags]
public enum MemProtect : int
{
    ZeroAccess = 0,
    NoAccess = 1,
    ReadOnly = 2,
    ReadWrite = 4,
    WriteCopy = 8,
    Execute = 16,
    ExecuteRead = 32,
    ExecuteReadWrite = 64,
    ExecuteWriteCopy = 128,
    Guard = 256,
    ReadWriteGuard = 260,
    NoCache = 512
}

public enum MemType : int
{
    Image = 0x1000000,
    Mapped = 0x40000,
    Private = 0x20000
}
#endregion

#region Struct
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MBI
{
    public byte* BaseAddress;
    public byte* AllocationBase;
    public uint AllocationProtect;
    public nint RegionSize;
    public MemState State;
    public MemProtect Protect;
    public MemType Type;

    public MemReg AsMemReg => new(BaseAddress, BaseAddress + RegionSize, RegionSize, State, Protect, Type);

    public override string ToString() => $"BaseAddr: {(nint)BaseAddress}, AllocAddr: {(nint)AllocationBase}, AllocProtect: {AllocationProtect}, Size: {RegionSize}, State: {State}, Protect: {Protect}, Type: {Type}";
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct MemReg
{
    public MemReg(byte* start, byte* end, nint size, MemState state, MemProtect protect, MemType type)
    {
        Start = start;
        End = end;
        Size = size;
        State = state;
        Protect = protect;
        Type = type;
    }

    public byte* Start;
    public byte* End;
    public IntPtr Size;
    public MemState State;
    public MemProtect Protect;
    public MemType Type;

    public override string ToString() => $"BaseAddr: {(nint)Start}, Size: {Size}, State: {State}, Protect: {Protect}, Type: {Type}";

    public nint GetModuleToAddr(nint addr) => Math.Abs((nint)Start - addr);
}
#endregion

internal class Interop
{
    [DllImport("kernel32")]
    internal unsafe static extern
        bool VirtualQuery(byte* address, MBI* buffer, int length);

    #region Method
    internal unsafe static MBI QueryVirtualMemory(byte* baseAddress)
    {
        MBI mbi;
        if (!VirtualQuery(baseAddress, &mbi, sizeof(MBI)))
            throw new Win32Exception();
        return mbi;
    }

    internal unsafe static List<MemReg> GetMemoryRegions(byte* baseAddress, Func<MBI, bool> filter)
    {
        var result = new List<MemReg>();
        MBI mbi;

        Query(baseAddress);

        while (true)
            try
            {
                Query(mbi.BaseAddress + mbi.RegionSize);
            }
            catch (Win32Exception) { break; }

        return result;

        void Query(byte* addr)
        {
            mbi = QueryVirtualMemory(addr);

            if (!filter(mbi))
                return;

            result.Add(mbi.AsMemReg);
        }
    }
    #endregion
}