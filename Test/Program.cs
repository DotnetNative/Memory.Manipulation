using Memory.Internal;
using Memory.SigScan.Patterns;

unsafe class Program
{
    static void Main()
    {
        var regs = Interop.GetMemoryRegions(filterGuard: true);
        var pattern = new SimpleBytePattern(new byte[] { 0x10, 0x20 });

        foreach (var reg in regs)
        {
            if (reg.Size < 21000000 && reg.Size > 19000000)
            {
                Console.WriteLine($"{((nint)reg.Start).ToString("X")} {reg.Size / 1024}");
                Console.ReadLine();
                var ptr = New(reg);
                pattern.Scan(ptr);
                Free(ptr);
                Console.ReadLine();
            }
        }
    }
}