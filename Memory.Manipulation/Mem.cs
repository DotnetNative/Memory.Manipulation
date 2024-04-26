namespace Memory;
public unsafe static class Mem
{
    public static List<MemReg> GetRegions() => Interop.GetMemoryRegions(null, mbi =>
    {
        if (mbi.State != MemState.Commit)
            return false;

        if (mbi.Protect == MemProtect.ZeroAccess)
            return false;

        if (mbi.Protect == MemProtect.Guard ||
            mbi.Protect == MemProtect.ReadWriteGuard ||
            mbi.Protect == MemProtect.NoAccess ||
            mbi.Protect == MemProtect.NoCache)
            return false;

        return true;
    });
    public static List<MemReg> GetRegions(Func<MBI, bool> filter) => Interop.GetMemoryRegions(null, filter);

    public static ValueBytePattern CreatePattern(byte val) => new ValueBytePattern(val);
    public static ValueShortPattern CreatePattern(short val, bool aligned = true) => new ValueShortPattern(val) { Aligned = aligned };
    public static ValueShortPattern CreatePattern(ushort val, bool aligned = true) => new ValueShortPattern(*(short*)val) { Aligned = aligned };
    public static ValueIntPattern CreatePattern(int val, bool aligned = true) => new ValueIntPattern(val) { Aligned = aligned };
    public static ValueIntPattern CreatePattern(float val, bool aligned = true)
    {
        var ptr = stackalloc int[1];
        *(float*)ptr = val;
        return new ValueIntPattern(*ptr) { Aligned = aligned };
    }
    public static ValueIntPattern CreatePattern(uint val, bool aligned = true) => new ValueIntPattern(*(int*)val) { Aligned = aligned };
    public static ValueLongPattern CreatePattern(long val, bool aligned = true) => new ValueLongPattern(val) { Aligned = aligned };
    public static ValueLongPattern CreatePattern(ulong val, bool aligned = true) => new ValueLongPattern(*(long*)val) { Aligned = aligned };
    public static ValueLongPattern CreatePattern(double val, bool aligned = true)
    {
        var ptr = stackalloc long[1];
        *(double*)ptr = val;
        return new ValueLongPattern(*ptr) { Aligned = aligned };
    }

    public static AbstractPattern CreatePattern(params byte[] mask)
    {
        int length = mask.Length;

        if (length == 0)
            return new EmptyPattern();

        if (length >= 3 && length <= 15 && length % 2 == 1)
            return new SimpleBytePattern(mask);

        if (length == 6 || length == 10 || length == 14)
        {
            var castedMask = new short[length / sizeof(short)];
            Copy(castedMask, mask, length * sizeof(short));
            return new SimpleShortPattern(castedMask);
        }

        if (length == 12)
        {
            var castedMask = new int[length / sizeof(int)];
            Copy(castedMask, mask, length * sizeof(int));
            return new SimpleIntPattern(castedMask);
        }

        if (length > 8 && length % sizeof(long) == 0)
        {
            var castedMask = new long[length / sizeof(long)];
            Copy(castedMask, mask, length);
            return new LongPattern(castedMask);
        }

        fixed (byte* ptr = mask)
        {
            if (length == 1)
                return CreatePattern(*ptr);

            if (length == 2)
                return CreatePattern(*(short*)ptr);

            if (length == 4)
                return CreatePattern(*(int*)ptr);

            if (length == 8)
                return CreatePattern(*(long*)ptr);

            var primaryLength = length / sizeof(long);
            var secondaryLength = length % sizeof(long);
            var primaryMask = new long[primaryLength];
            var secondaryMask = new byte[secondaryLength];
            Copy(primaryMask, ptr, primaryLength);
            Copy(secondaryMask, ptr + length - secondaryLength, secondaryLength);

            return new HardPattern(primaryMask, secondaryMask);
        }
    }

    public static List<nint> Scan(AbstractPattern pattern, params MemReg[] regs) => Scan(pattern, regs.ToList());
    public static List<nint> Scan(AbstractPattern pattern, List<MemReg> regs)
    {
        var result = new List<nint>();

        foreach (var reg in regs)
            pattern.Scan(result, &reg);

        return result;
    }

    public static nint CalcOffsets(nint baseAddr, params int[] offsets)
    {
        var result = baseAddr;
        foreach (var offset in offsets)
        {
            result += offset;
            result = *(nint*)result;
        }

        return result;
    }
}