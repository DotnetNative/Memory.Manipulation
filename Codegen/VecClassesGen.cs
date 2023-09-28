using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codegen;
public class VecClassesGen
{
    public static void Exec(int count = 16)
    {
        Console.WriteLine(string.Join("\n", Enumerable.Range(2, count).Select(i =>
        {
            var genericTypes = $"<{string.Join(", ", Enumerable.Range(0, i).Select(GenType))}>";
            var properties = string.Join(", ", Enumerable.Range(0, i).Select(index => $"{GenType(index)} {GenPropertyName(index)}"));
            var interfaces = string.Join('\n', Enumerable.Range(0, i).Select(index => $"where {GenType(index)} : unmanaged"));
            return 
$@"
public unsafe record struct Vec{genericTypes}({properties})
    where T : unmanaged 
    where T1 : unmanaged
{{
    public static implicit operator Vec{genericTypes}((T a0, T1 a1) a) => new(a.a0, a.a1);
    public static implicit operator Vec{genericTypes}(Vec{genericTypes}* a) => new(a->_, a->_1);
    public static explicit operator (T a0, T1 a1)({genericTypes} a) => (a._, a._1);
}}
";
            string GenType(int index) => index == 0 ? "T" : $"T{index}";
            string GenPropertyName(int index) => index == 0 ? "_" : $"_{index}";
            string GenArgName(int index) => $"a{index}";
        })));
    }
}