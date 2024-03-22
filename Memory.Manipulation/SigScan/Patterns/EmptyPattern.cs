using Memory.Internal;

namespace Memory.SigScan.Patterns;
public class EmptyPattern : AbstractPattern
{
    public EmptyPattern() : base(0) { }

    public override unsafe void Scan(List<nint> result, MemReg* regPtr) { }
}