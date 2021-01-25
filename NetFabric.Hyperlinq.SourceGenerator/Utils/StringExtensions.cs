using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class StringExtensions
    {
        public static string ToCommaSeparated(this string[] strings)
            => string.Join(", ", strings);

        public static string ToCommaSeparated(this IEnumerable<string> strings)
            => string.Join(", ", strings);

        public static string ToCommaSeparated(this IReadOnlyList<string> strings)
            => strings.Count switch
            {
                0 => string.Empty,
                1 => strings[0],
                _ => AppendCommaSeparated(new StringBuilder(), strings).ToString(),
            };

        public static StringBuilder AppendCommaSeparated(this StringBuilder builder, IReadOnlyList<string> strings)
            => strings.Count switch
            {
                0 => builder,
                1 => builder.Append(strings[0]),
                _ => PerformAppendCommaSeparated(builder, strings),
            };

        static StringBuilder PerformAppendCommaSeparated(this StringBuilder builder, IReadOnlyList<string> strings)
        {
            _ = builder.Append(strings[0]);
            for (var index = 1; index < strings.Count; index++)
            {
                _ = builder.Append(", ").Append(strings[index]);
            }
            return builder;
        }

        public static string ApplyMappings(this string value, ImmutableArray<(string, string, bool)> genericsMapping, out bool isConcreteType)
        {
            var result = value;
            isConcreteType = false;
            if (!genericsMapping.IsDefault)
            {
                foreach (var (from, to, isConcreteType2) in genericsMapping.Reverse())
                {
                    if (value == from && isConcreteType2)
                    {
                        isConcreteType = true;
                        return value.Replace(from, to);
                    }
                    result = result.Replace(from, to);
                }
            }
            return result;
        }
    }
}
