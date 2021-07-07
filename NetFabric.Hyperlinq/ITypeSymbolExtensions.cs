using Microsoft.CodeAnalysis;
using NetFabric.CodeAnalysis;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

// ReSharper disable LoopCanBeConvertedToQuery

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class ITypeSymbolExtensions
    {
        public static bool ImplementsAnyInterface(this ITypeSymbol typeSymbol, INamedTypeSymbol[] interfaceTypes, out ImmutableArray<ITypeSymbol> genericArguments)
        {
            if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
            {
                foreach (var interfaceType in interfaceTypes)
                {
                    if (SymbolEqualityComparer.Default.Equals(namedTypeSymbol.OriginalDefinition, interfaceType))
                    {
                        genericArguments = namedTypeSymbol.TypeArguments;
                        return true;
                    }
                }
            }

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var @interface in typeSymbol.AllInterfaces)
            {
                foreach (var interfaceType in interfaceTypes)
                {
                    if (SymbolEqualityComparer.Default.Equals(@interface.OriginalDefinition, interfaceType))
                    {
                        genericArguments = @interface.TypeArguments;
                        return true;
                    }
                }
            }

            Unsafe.SkipInit(out genericArguments);
            return false;
        }

        public static ValueEnumerableType? ToValueEnumerableType(this ITypeSymbol typeSymbol, TypeSymbolsCache typeSymbolsCache) 
            => !typeSymbol.ImplementsInterface(typeSymbolsCache[typeof(IValueEnumerable<,>)]!, out var genericArguments)
                ? null
                : new ValueEnumerableType(
                    Name: typeSymbol.ToDisplayString(),
                    EnumeratorType: genericArguments[1].ToDisplayString(),
                    ItemType: genericArguments[0].ToDisplayString(),
                    IsCollection: typeSymbol.ImplementsInterface(typeSymbolsCache[typeof(IValueReadOnlyCollection<,>)]!, out _),
                    IsList: typeSymbol.ImplementsInterface(typeSymbolsCache[typeof(IValueReadOnlyList<,>)]!, out _));
    }
}
