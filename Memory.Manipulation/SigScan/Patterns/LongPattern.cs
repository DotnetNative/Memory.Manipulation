namespace Memory.SigScan;
/* Only for patterns with [n % sizeof(long)] length */
public unsafe class LongPattern : AbstractPattern
{
    public LongPattern(params long[] mask) : base(mask.Length * sizeof(long))
    {
        Mask = mask;
        Size = (byte)mask.Length;
    }

    public readonly long[] Mask;
    public readonly byte Size;
    public const byte TypeSize = sizeof(long);

    public byte* GetEnd(byte* end) => end - (Size * TypeSize - 1);

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var size = Size;
        var align = TypeSize;
        var mask = stackalloc long[size];
        Copy(mask, Mask);

        var reg = *regPtr;
        var start = reg.Start;
        var end = GetEnd(reg.End);

        byte degress = 0;
        var defVal = mask[0];
        var val = defVal;
        while (start < end)
        {
            if (*((long*)start + degress) == val)
            {
                degress++;
                val = mask[degress];
                if (degress == size)
                {
                    result.Add((nint)start);
                    degress = 0;
                    val = defVal;
                    start += align;
                }
            }
            else
            {
                degress = 0;
                val = defVal;
                start += align;
            }
        }
    }
}