using static System.Linq.Enumerable;
using static System.String;

namespace Codegen;
public class VecClassesGen
{
    public static string Exec(int count = 16) => Join("\n", Range(2, count).Select(i =>
    {
        string genericTypes = $"<{Join(", ", Range(0, i).Select(GenType))}>",
            properties = Join(", ", Range(0, i).Select(index => $"{GenType(index)} {GenPropertyName(index)}")),
            interfaces = Join('\n', Range(0, i).Select(index => $"        where {GenType(index)} : unmanaged")),
            methArgs = Join(", ", Range(0, i).Select(index => $"{GenType(index)} {GenArgName(index)}")),
            ctorArgs = Join(", ", Range(0, i).Select(index => $"a.{GenArgName(index)}")),
            ctorPtrArgs = Join(", ", Range(0, i).Select(index => $"a->{GenPropertyName(index)}")),
            anonArgs = Join(", ", Range(0, i).Select(index => $"a.{GenPropertyName(index)}"));
        return
$@"
[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec{genericTypes}({properties})
{interfaces}
{{
    public static implicit operator Vec{genericTypes}(({methArgs}) a) => new({ctorArgs});
    public static implicit operator Vec{genericTypes}(Vec{genericTypes}* a) => new({ctorPtrArgs});
    public static explicit operator ({methArgs})(Vec{genericTypes} a) => ({anonArgs});
}}";
        string GenType(int index) => index == 0 ? "T" : $"T{index}";
        string GenPropertyName(int index) => index == 0 ? "_" : $"_{index}";
        string GenArgName(int index) => $"a{index}";
    }));
}
