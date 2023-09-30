using Memory.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.SigScan.Patterns;
public abstract class SimplePattern : AbstractPattern
{

}

/* Only for patterns with 1, 3, 5, 6, 7 length */
public class SimpleBytePattern : SimplePattern
{
    public SimpleBytePattern(byte[] mask)
    {
        Mask = mask;
        Size = (byte)mask.Length;
    }

    public byte[] Mask;
    public byte Size;

    public override unsafe void Scan(List<nint> result, MemReg* regPtr)
    {
        var size = Size;
        var mask = stackalloc byte[size];
        Copy(mask, Mask);

        var reg = *regPtr;
        var start = reg.Start;
        var end = reg.End;

        byte degress = 0;
        for (; start < end; start++)
        {
            if (start[degress] == mask[degress])
            {
                degress++;
                if (degress == size)
                {
                    result.Add((nint)start);
                    degress = 0;
                    start++;
                }
            }
            else
            {
                degress = 0;
                start++;
            }
        }
    }
}