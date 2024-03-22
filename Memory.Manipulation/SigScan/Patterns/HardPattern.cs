using Memory.Internal;

namespace Memory.SigScan.Patterns;
public unsafe class HardPattern : AbstractPattern
{
    public HardPattern(long[] primaryMask, byte[] secondaryMask) : base(primaryMask.Length * sizeof(long) + secondaryMask.Length)
    {
        PrimaryMask = primaryMask;
        SecondaryMask = secondaryMask;
    }

    public const byte PrimaryTypeSize = sizeof(long);
    public const byte SecondaryTypeSize = sizeof(byte);

    public readonly long[] PrimaryMask;
    public readonly byte[] SecondaryMask;
    public readonly int PrimarySize;
    public readonly int SecondarySize;

    public byte* GetEnd(byte* end) => end - (PrimarySize * PrimaryTypeSize - SecondarySize * SecondaryTypeSize - 1);

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var primaryAlign = sizeof(long);
        var primarySize = PrimarySize;
        var primaryMask = stackalloc long[primarySize];
        Copy(primaryMask, PrimaryMask);

        var secondaryAlign = sizeof(byte);
        var secondarySize = SecondarySize;
        var secondaryMask = stackalloc byte[secondarySize];
        Copy(secondaryMask, SecondaryMask);

        var reg = *regPtr;
        var start = reg.Start;
        var end = GetEnd(reg.End);

        byte primaryDegress = 0;
        var primaryDefVal = primaryMask[0];
        var primaryVal = primaryDefVal;
        for (; start < end;)
        {
            if (*((long*)start + primaryDegress) == primaryVal)
            {
                primaryDegress++;
                primaryVal = primaryMask[primaryDegress];
                if (primaryDegress == primarySize)
                {

                    //result.Add((nint)start);

                    primaryDegress = 0;
                    primaryVal = primaryDefVal;
                    start += primaryAlign;
                }
            }
            else
            {
                primaryDegress = 0;
                primaryVal = primaryDefVal;
                start += primaryAlign;
            }
        }
    }
}