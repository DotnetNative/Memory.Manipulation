namespace Memory;

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
    public nint Size;
    public MemState State;
    public MemProtect Protect;
    public MemType Type;

    public bool IsCommited => State == MemState.Commit;
    public bool IsFree => State == MemState.Free;

    static MemProtect[] ReadProtects = [MemProtect.ReadWrite, MemProtect.ReadOnly, MemProtect.ExecuteRead, MemProtect.ExecuteReadWrite];
    public bool IsReadable => ReadProtects.Contains(Protect);

    static MemProtect[] WriteProtects = [MemProtect.WriteCopy, MemProtect.ReadWrite, MemProtect.ExecuteReadWrite, MemProtect.ExecuteWriteCopy];
    public bool IsWriteable => ReadProtects.Contains(Protect);

    public static MemProtect[] GuardProtects = [MemProtect.Guard, MemProtect.ReadWriteGuard];
    public bool HasGuard => GuardProtects.Contains(Protect);    

    public override string ToString() => $"BaseAddr: {(pointer)Start}, Size: {Size}, State: {State}, Protect: {Protect}, Type: {Type}";
}