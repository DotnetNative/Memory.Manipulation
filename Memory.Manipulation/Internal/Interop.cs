namespace Memory;
internal unsafe class Interop
{
    [DllImport("kernel32")] internal static extern
        bool VirtualQuery(pointer address, MBI* buffer, int length);

    internal static MBI QueryVirtualMemory(pointer baseAddress)
    {
        MBI mbi;
        if (!VirtualQuery(baseAddress, &mbi, sizeof(MBI)))
            throw new Win32Exception();
        return mbi;
    }

    internal static List<MemReg> GetMemoryRegions(pointer baseAddress, Func<MBI, bool> filter)
    {
        List<MemReg> result = new(512);
        MBI mbi;

        Query(baseAddress);

        while (true)
            try { Query(mbi.BaseAddress + mbi.RegionSize); }
            catch (Win32Exception) { break; }

        return result;

        void Query(pointer addr)
        {
            mbi = QueryVirtualMemory(addr);

            if (filter(mbi))
                result.Add(mbi.AsMemReg);
        }
    }
}