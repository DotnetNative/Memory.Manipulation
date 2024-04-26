namespace Memory.SigScan;
public unsafe abstract class ValuePattern : AbstractPattern
{
    public ValuePattern(byte typeSize) : base(typeSize) => TypeSize = typeSize;

    public bool Aligned;
    public readonly byte TypeSize;

    public byte* GetEnd(byte* end) => end - (TypeSize - 1);
}

public unsafe class ValueBytePattern : ValuePattern
{
    public ValueBytePattern(byte value) : base(sizeof(byte)) => Value = value;

    public readonly byte Value;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var value = Value;

        var reg = *regPtr;
        var start = reg.Start;
        var end = GetEnd(reg.End);

        for (; start < end;)
        {
            if (*start == value)
                result.Add((nint)start);
            start++;
        }
    }
}

public unsafe class ValueShortPattern : ValuePattern
{
    public ValueShortPattern(short value) : base(sizeof(short)) => Value = value;

    public readonly short Value;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var value = Value;

        var reg = *regPtr;
        var start = (short*)reg.Start;
        var end = GetEnd(reg.End);

        if (Aligned)
        {
            for (; start < end;)
            {
                if (*start == value)
                    result.Add((nint)start);
                start++;
            }
        }
        else
        {
            for (; start < end;)
            {
                if (*start == value)
                    result.Add((nint)start);
                start = (short*)(((byte*)start) + 1);
            }
        }
    }
}

public unsafe class ValueIntPattern : ValuePattern
{
    public ValueIntPattern(int value) : base(sizeof(int)) => Value = value;

    public readonly int Value;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var value = Value;

        var reg = *regPtr;
        var start = (int*)reg.Start;
        var end = GetEnd(reg.End);

        if (Aligned)
        {
            for (; start < end;)
            {
                if (*start == value)
                    result.Add((nint)start);
                start++;
            }
        }
        else
        {
            for (; start < end;)
            {
                if (*start == value)
                    result.Add((nint)start);
                start = (int*)(((byte*)start) + 1);
            }
        }
    }
}

public unsafe class ValueLongPattern : ValuePattern
{
    public ValueLongPattern(long value) : base(sizeof(long)) => Value = value;

    public readonly long Value;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var value = Value;

        var reg = *regPtr;
        var start = (long*)reg.Start;
        var end = GetEnd(reg.End);

        if (Aligned)
        {
            for (; start < end;)
            {
                if (*start == value)
                    result.Add((nint)start);
                start++;
            }
        }
        else
        {
            for (; start < end;)
            {
                if (*start == value)
                    result.Add((nint)start);
                start = (long*)(((byte*)start) + 1);
            }
        }
    }
}