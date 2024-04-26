namespace Memory.SigScan;
public unsafe abstract class AbstractPattern
{
    public AbstractPattern(int length) => Length = length;

    public readonly int Length;

    public abstract void Scan(List<nint> result, MemReg* regPtr);

    public List<nint> Scan(MemReg* regPtr)
    {
        var result = new List<nint>();
        Scan(result, regPtr);
        return result;
    }
}