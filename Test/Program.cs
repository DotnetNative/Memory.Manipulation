using Memory;

unsafe class Program
{
    static void Main()
    {
        var allRegions = Mem.GetAllRegions();

        var suitRegions = Mem.GetRegions(mbi => mbi.Protect == MemProtect.ExecuteWriteCopy && mbi.RegionSize == 0x1000);
        var pattern = Mem.CreatePattern(2024d); // Create 8 bytes pattern for double number '2024'
        var found = Mem.Scan(pattern, suitRegions);

        var firstAddress = found[0];
        var destAddress = Mem.SafeCalcOffsets(firstAddress, 0, 0x30, 8);

        var newPattern = Mem.CreatePattern([0, 0x2F, 0x90, null]);
    }
}