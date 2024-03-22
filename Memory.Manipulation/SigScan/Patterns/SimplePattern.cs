using Memory.Internal;

namespace Memory.SigScan.Patterns;
public abstract unsafe class SimplePattern : AbstractPattern
{
    public SimplePattern(int size, int typeSize) : base(size * typeSize)
    {
        Size = (byte)size;
        TypeSize = (byte)typeSize;
    }

    public readonly byte Size;
    public readonly byte TypeSize;

    public byte* GetEnd(byte* end) => end - (Size * TypeSize - 1);
}

/* Only for patterns with [3, 5, 7, 9, 11, 13, 15] length */
public class SimpleBytePattern : SimplePattern
{
    public SimpleBytePattern(params byte[] mask) : base(mask.Length, sizeof(byte))
    {
        Mask = mask;
    }

    public readonly byte[] Mask;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var size = Size;
        var mask = stackalloc byte[size];
        Copy(mask, Mask);

        var reg = *regPtr;
        var start = reg.Start;
        var end = GetEnd(reg.End);

        byte degress = 0;
        var defVal = mask[0];
        var val = defVal;
        for (; start < end;)
        {
            if (start[degress] == val)
            {
                degress++;
                val = mask[degress];
                if (degress == size)
                {
                    result.Add((nint)start);
                    degress = 0;
                    val = defVal;
                    start++;
                }
            }
            else
            {
                degress = 0;
                val = defVal;
                start++;
            }
        }
    }
}

/* Only for patterns with [12] length */
public class SimpleShortPattern : SimplePattern
{
    public SimpleShortPattern(params short[] mask) : base(mask.Length, sizeof(short))
    {
        Mask = mask;
    }

    public readonly short[] Mask;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var size = Size;
        var align = TypeSize;
        var mask = stackalloc short[size];
        Copy(mask, Mask);

        var reg = *regPtr;
        var start = reg.Start;
        var end = GetEnd(reg.End);

        byte degress = 0;
        var defVal = mask[0];
        var val = defVal;
        for (; start < end;)
        {
            if (*((short*)start + degress) == val)
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

/* Only for patterns with [6, 10, 14] length */
public class SimpleIntPattern : SimplePattern
{
    public SimpleIntPattern(params int[] mask) : base(mask.Length, sizeof(int))
    {
        Mask = mask;
    }

    public readonly int[] Mask;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var size = Size;
        var align = TypeSize;
        var mask = stackalloc int[size];
        Copy(mask, Mask);

        var reg = *regPtr;
        var start = reg.Start;
        var end = GetEnd(reg.End);

        byte degress = 0;
        var defVal = mask[0];
        var val = defVal;
        for (; start < end;)
        {
            if (*((int*)start + degress) == val)
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