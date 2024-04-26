namespace Memory.SigScan;
public class MultiPattern : AbstractPattern
{
    public MultiPattern(List<AbstractPattern> patternts) : base(-1) => Patterns = patternts;

    public readonly List<AbstractPattern> Patterns;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        for (var i = 0; i < Patterns.Count; i++)
        {
            var pattern = Patterns[i];
            pattern.Scan(result, regPtr);
        }
    }
}