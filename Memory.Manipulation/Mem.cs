namespace Memory;
public unsafe static class Mem
{
    #region GetRegions
    public static List<MemReg> GetRegions(Func<MBI, bool> filter) => Interop.GetMemoryRegions(0, filter);

    public static List<MemReg> GetAllRegions() => Interop.GetMemoryRegions(0, _ => true);
    public static List<MemReg> GetAccesibleRegions() => Interop.GetMemoryRegions(0, mbi =>
    {
        if (mbi.State != MemState.Commit ||
            mbi.Protect == MemProtect.ZeroAccess ||
            mbi.Protect == MemProtect.Guard ||
            mbi.Protect == MemProtect.ReadWriteGuard ||
            mbi.Protect == MemProtect.NoAccess ||
            mbi.Protect == MemProtect.NoCache)
            return false;

        return true;
    });
    public static List<MemReg> GetCommitedRegions() => GetRegions(mbi => mbi.State == MemState.Commit);
    public static List<MemReg> GetReadableRegions() => GetAccesibleRegions().Where(reg => reg.IsReadable).ToList();
    public static List<MemReg> GetWriteableRegions() => GetAccesibleRegions().Where(reg => reg.IsWriteable).ToList();
    #endregion

    #region CreatePattern
    public static AbstractPattern? CreatePattern(string pattern)
    {
        try
        {
            var splitted = pattern.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var bytes = new byte?[splitted.Length];
            for (var i = 0; i < splitted.Length; i++)
                bytes[i] = byte.TryParse(splitted[i], NumberStyles.HexNumber, null, out byte result) ? result : null;

            return CreatePattern(bytes);
        } catch { return null; }
    }

    public static ValueBytePattern CreatePattern(byte val) => new(val);
    public static ValueShortPattern CreatePattern(short val, bool aligned = true) => new(val) { Aligned = aligned };
    public static ValueShortPattern CreatePattern(ushort val, bool aligned = true) => new((short)val) { Aligned = aligned };
    public static ValueIntPattern CreatePattern(int val, bool aligned = true) => new(val) { Aligned = aligned };
    public static ValueIntPattern CreatePattern(float val, bool aligned = true) => new(*(int*)&val) { Aligned = aligned };
    public static ValueIntPattern CreatePattern(uint val, bool aligned = true) => new((int)val) { Aligned = aligned };
    public static ValueLongPattern CreatePattern(long val, bool aligned = true) => new(val) { Aligned = aligned };
    public static ValueLongPattern CreatePattern(ulong val, bool aligned = true) => new((long)val) { Aligned = aligned };
    public static ValueLongPattern CreatePattern(double val, bool aligned = true) => new(*(long*)&val) { Aligned = aligned };
    public static ValueLongPattern CreatePattern(pointer val, bool aligned = true) => new((long)val.Address) { Aligned = aligned };

    public static AbstractPattern CreatePattern(params byte[] mask)
    {
        var length = mask.Length;

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
        }

        return new SimpleBytePattern(mask);
    }

    public static AbstractPattern CreatePattern(byte?[] mask)
    {
        foreach (var part in mask)
            if (part is null)
                return new SimpleCustomPattern(mask);
        return CreatePattern(mask.Select(b => b.Value).ToArray());
    }
    #endregion

    #region Scan
    public static List<nint> Scan(AbstractPattern pattern, params MemReg[] regs) => Scan(pattern, regs.ToList());
    public static List<nint> Scan(AbstractPattern pattern, List<MemReg> regs)
    {
        List<nint> result = [];

        foreach (var reg in regs)
            pattern.Scan(result, &reg);

        return result;
    }
    #endregion

    #region IsValid
    public static bool IsValid(List<MemReg> regs, pointer pointer)
    {
        foreach (var reg in regs)
            if (reg.Start <= pointer && pointer <= reg.End)
                return true;

        return false;
    }

    public static bool IsValid(pointer pointer) => IsValid(GetCommitedRegions(), pointer);
    #endregion

    #region CalcOffsets
    public static pointer CalcOffsets(pointer baseAddr, params int[] offsets)
    {
        var result = baseAddr;
        foreach (var offset in offsets)
            result = *(nint*)(result + offset);

        return result;
    }

    public static pointer? SafeCalcOffsets(pointer baseAddr, params int[] offsets)
    {
        var readableRegions = GetReadableRegions();
        var result = baseAddr;
        foreach (var offset in offsets)
        {
            result += offset;
            if (!IsValid(readableRegions, result) || !IsValid(readableRegions, (nint)result + 7))
                return null;
            result = *(pointer*)result;
        }

        return result;
    }
    #endregion
}