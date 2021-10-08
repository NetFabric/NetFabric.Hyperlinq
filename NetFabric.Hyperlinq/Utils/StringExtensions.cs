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
        {
            return strings.Count switch
            {
                0 => builder,
                1 => builder.Append(strings[0]),
                _ => PerformAppendCommaSeparated(builder, strings),
            };

            static StringBuilder PerformAppendCommaSeparated(StringBuilder builder, IReadOnlyList<string> strings)
            {
                _ = builder.Append(strings[0]);
                for (var index = 1; index < strings.Count; index++)
                {
                    _ = builder.Append(", ").Append(strings[index]);
                }
                return builder;
            }
        }

        public static string CommaSeparateIfNotNullOrEmpty(params string?[] args)
        {
            return args.Length switch
            {
                0 => string.Empty,
                1 => args[0] switch
                    {  
                        null or { Length: 0 } => string.Empty,
                        _ => args[0]!
                    },
                _ => Append(args)
            };

            static string Append(params string?[] args)
            {
                var builder = new StringBuilder();
                foreach (var arg in args)
                {
                    if (arg is not null and { Length: not 0 })
                    {
                        if (builder.Length is not 0)
                            _ = builder.Append(", ");

                        _ = builder.Append(arg);
                    }
                }
                return builder.ToString();
            }
        }

        public static string ApplyMappings(this string value, ImmutableArray<GeneratorMappingAttribute> genericsMapping, out bool isConcreteType)
        {
            var result = value;
            isConcreteType = false;
            if (!genericsMapping.IsDefault)
            {
                foreach (var mapping in genericsMapping.Reverse())
                {
                    if (value == mapping.From && mapping.IsType)
                    {
                        isConcreteType = true;
                        return value.Replace(mapping.From, mapping.To);
                    }
                    result = result.Replace(mapping.From, mapping.To);
                }
            }
            return result;
        }
    }
}
