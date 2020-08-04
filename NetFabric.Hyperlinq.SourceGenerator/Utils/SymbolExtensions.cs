using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class SymbolExtensions
    {
        static INamedTypeSymbol? ignoreAttributeSymbol;

        static INamedTypeSymbol GetGeneratorIgnoreAttributeSymbol(Compilation compilation)
            => ignoreAttributeSymbol ??= compilation.GetTypeByMetadataName("NetFabric.Hyperlinq.GeneratorIgnoreAttribute")!;

        public static bool IsPublic(this ISymbol typeSymbol) 
            => typeSymbol.DeclaredAccessibility == Accessibility.Public;

        public static bool ShouldIgnore(this ISymbol symbol, Compilation compilation)
        {
            var attribute = symbol.GetAttribute(GetGeneratorIgnoreAttributeSymbol(compilation));
            return attribute is object
                && (bool)attribute.ConstructorArguments[0].Value!;
        }

        public static AttributeData GetAttribute(this ISymbol property, INamedTypeSymbol attributeClassSymbol) 
            => property.GetAttributes().FirstOrDefault(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, attributeClassSymbol));

    }
}
