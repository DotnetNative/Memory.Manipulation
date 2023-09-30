using Memory.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.SigScan.Patterns;
public unsafe abstract class AbstractPattern
{
    public abstract void Scan(List<nint> result, MemReg* regPtr);

    public List<nint> Scan(MemReg* regPtr)
    {
        var result = new List<nint>();
        Scan(result, regPtr);
        return result;
    }
}