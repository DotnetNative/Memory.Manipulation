using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Internal;
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
    public MemReg AsMemReg => new MemReg(BaseAddress, BaseAddress + RegionSize, RegionSize, State, Protect, Type);
    public unsafe byte* BaseAddress;

    public unsafe byte* AllocationBase;

    public uint AllocationProtect;

    public nint RegionSize;

    public MemState State;

    public MemProtect Protect;

    public MemType Type;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct MemReg
{
    public unsafe MemReg(byte* start, byte* end, nint size, MemState state, MemProtect protect, MemType type)
    {
        Start = start;
        End = end;
        Size = size;
        State = state;
        Protect = protect;
        Type = type;
    }

    public unsafe byte* Start;
    public unsafe byte* End;
    public IntPtr Size;
    public MemState State;
    public MemProtect Protect;
    public MemType Type;
}
#endregion

public/*internal*/ class Interop
{
    #region DllImport
    const string kernel = "kernel32";

    [DllImport(kernel)]
    public unsafe static extern bool VirtualQuery(byte* lpAddress, MBI* lpBuffer, int dwLength);
    #endregion

    #region Method
    public unsafe static MBI QueryVirtualMemory(byte* baseAddress)
    {
        var mbi = new MBI();
        if (!VirtualQuery(baseAddress, &mbi, sizeof(MBI)))
            throw new Win32Exception();
        return mbi;
    }

    public unsafe static List<MemReg> GetMemoryRegions(byte* baseAddress = null, bool filterGuard = false)
    {
        List<MemReg> result = new();
        MBI mbi = new MBI();

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

            if (mbi.State != MemState.Commit)
                return;

            if (mbi.Protect == MemProtect.ZeroAccess)
                return;

            if (filterGuard)
                if (mbi.Protect == MemProtect.Guard || mbi.Protect == MemProtect.ReadWriteGuard)
                    return;

            result.Add(mbi.AsMemReg);
        }
    }
    #endregion
}