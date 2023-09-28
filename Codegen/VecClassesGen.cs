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
            var interfaces = string.Join('\n', Enumerable.Range(0, i).Select(index => $"        where {GenType(index)} : unmanaged"));
            var methArgs = string.Join(", ", Enumerable.Range(0, i).Select(index => $"{GetType(index)} {GetArgName(index)}"));
            var ctorArgs = string.Join(", ", Enumerable.Range(0, i).Select(index => $"a.{GetArgName(index)}"));
            var ctorPtrArgs = string.Join(", ", Enumerable.Range(0, i).Select(index => $"a->{GetPropertyName(index)}"));
            var anonArgs = string.Join(", ", Enumerable.Range(0, i).Select(index => $"a.{GetPropertyName(index)}"));
            return 
$@"
public unsafe record struct Vec{genericTypes}({properties})
{interfaces}
{{
    public static implicit operator Vec{genericTypes}(({methArgs}) a) => new({ctorArgs});
    public static implicit operator Vec{genericTypes}(Vec{genericTypes}* a) => new({ctorPtrArgs});
    public static explicit operator ({methArgs})({genericTypes} a) => ({anonArgs});
}}
";
            string GenType(int index) => index == 0 ? "T" : $"T{index}";
            string GenPropertyName(int index) => index == 0 ? "_" : $"_{index}";
            string GenArgName(int index) => $"a{index}";
        })));
    }
}
