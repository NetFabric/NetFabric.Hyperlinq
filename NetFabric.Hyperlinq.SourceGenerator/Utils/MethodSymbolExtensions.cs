using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class MethodSymbolExtensions
    {
        public static string ToDisplayString(this IMethodSymbol method, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, ImmutableArray<(string, string, bool)> genericsMapping)
            => $"{method.Name}{method.TypeArguments.AsTypeArgumentsString(enumerableType, enumeratorType, genericsMapping)}";

        public static bool SameAs(this IMethodSymbol method0, IMethodSymbol method1, int offset = 0)
            => method0.Name == method1.Name && method0.Parameters.SameAs(method1.Parameters, offset);
    }
}
