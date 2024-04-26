namespace Memory.SigScan;
public class EmptyPattern : AbstractPattern
{
    public EmptyPattern() : base(0) { }

    public override unsafe void Scan(List<nint> result, MemReg* regPtr) { }
}