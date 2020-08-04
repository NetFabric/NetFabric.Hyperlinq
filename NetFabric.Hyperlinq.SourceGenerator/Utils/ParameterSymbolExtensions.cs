using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class ParameterSymbolExtensions
    {
        public static string AsParametersString(this ImmutableArray<IParameterSymbol> parameters) 
            => parameters.Length == 0 
                ? string.Empty 
                : parameters.Select(parameter => parameter.Name).ToCommaSeparated();

        public static string AsParametersDeclarationString(this ImmutableArray<IParameterSymbol> parameters, ImmutableArray<(string, string, bool)> genericsMapping)
            => parameters.Length switch
            {
                0 => string.Empty,
                1 => string.Empty,
                _ => parameters
                    .Skip(1)
                    .Select(parameter => {
                        var builder = new StringBuilder($"{parameter.Type.ToDisplayString(genericsMapping)} {parameter.Name}");
                        if (parameter.HasExplicitDefaultValue)
                        {
                            _ = parameter.ExplicitDefaultValue is null
                            ? builder.Append(" = default")
                            : builder.Append($" = {parameter.ExplicitDefaultValue}");
                        }
                        return builder.ToString();
                    })
                    .ToCommaSeparated(),
            };

        public static bool SameAs(this ImmutableArray<IParameterSymbol> parameters0, ImmutableArray<IParameterSymbol> parameters1, int offset = 0)
        {
            if (parameters0.Length != parameters1.Length + offset)
                return false;

            for (var index = 0; index < parameters1.Length; index++)
            {
                if (parameters0[index + offset].Type.ToDisplayString() != parameters1[index].Type.ToDisplayString())
                    return false;
            }

            return true;
        }

    }
}
