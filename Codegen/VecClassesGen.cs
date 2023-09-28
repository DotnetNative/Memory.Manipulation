using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Linq.Enumerable;
using static System.String;
using System.Threading.Tasks;

namespace Codegen;
public class VecClassesGen
{
    public static string Exec(int count = 16) => Join("\n", Range(2, count).Select(i =>
    {
        var genericTypes = $"<{Join(", ", Range(0, i).Select(GenType))}>",
            properties = string.Join(", ", Range(0, i).Select(index => $"{GenType(index)} {GenPropertyName(index)}")),
            interfaces = string.Join('\n', Range(0, i).Select(index => $"        where {GenType(index)} : unmanaged")),
            methArgs = string.Join(", ", Range(0, i).Select(index => $"{GetType(index)} {GetArgName(index)}")),
            ctorArgs = string.Join(", ", Range(0, i).Select(index => $"a.{GetArgName(index)}")),
            ctorPtrArgs = string.Join(", ", Range(0, i).Select(index => $"a->{GetPropertyName(index)}")),
            anonArgs = string.Join(", ", Range(0, i).Select(index => $"a.{GetPropertyName(index)}"));
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
