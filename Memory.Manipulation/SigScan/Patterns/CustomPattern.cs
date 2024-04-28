namespace Memory.SigScan;
public abstract class CustomPattern : AbstractPattern
{
    public CustomPattern(int length) : base(length) { }
}

public class SimpleCustomPattern : CustomPattern
{
    public SimpleCustomPattern(params byte?[] mask) : base(mask.Length) => Mask = mask;

    public readonly byte?[] Mask;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var mask = stackalloc NullableByte[Length];

        for (var i = 0; i < Mask.Length; i++)
        {
            if (Mask[i].HasValue)
                mask[i].Value = Mask[i]!.Value;
            else mask[i].IsNull = true;
        }

        var reg = *regPtr;
        var start = reg.Start;
        var end = reg.End - Mask.Length;

        var degress = 0;
        var defVal = mask[0];
        var val = defVal;

        while (start < end)
        {
            if (val.IsNull)
            {
                degress++;
            }    

            if (val.IsNull || val.Value == start[degress])
            {
                degress++;
                val = mask[degress];
                if (degress == Length)
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

    [StructLayout(LayoutKind.Sequential)]
    struct NullableByte
    {
        public byte Value;
        public bool IsNull;
    }
}