namespace Memory;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MBI
{
    public byte* BaseAddress;
    public pointer AllocationBase;
    public uint AllocationProtect;
    public nint RegionSize;
    public MemState State;
    public MemProtect Protect;
    public MemType Type;

    public MemReg AsMemReg => new(BaseAddress, BaseAddress + RegionSize - 1, RegionSize, State, Protect, Type);

    public override string ToString() => $"BaseAddr: {(pointer)BaseAddress}, AllocAddr: {AllocationBase}, AllocProtect: {AllocationProtect}, Size: {RegionSize}, State: {State}, Protect: {Protect}, Type: {Type}";
}