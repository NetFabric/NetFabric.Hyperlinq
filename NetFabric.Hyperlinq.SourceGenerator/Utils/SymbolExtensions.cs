using Microsoft.CodeAnalysis;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class SymbolExtensions
    {
        public static bool IsPublic(this ISymbol typeSymbol) 
            => typeSymbol.DeclaredAccessibility == Accessibility.Public;

        public static bool ShouldIgnore(this ISymbol symbol, Compilation compilation)
        {
            var attributeSymbol = compilation.GetTypeByMetadataName("NetFabric.Hyperlinq.GeneratorIgnoreAttribute");
            if (attributeSymbol is null)
                return false;
            var attribute = symbol.GetAttribute(attributeSymbol);
            return attribute is object
                && (bool)attribute.ConstructorArguments[0].Value!;
        }

        public static AttributeData? GetAttribute(this ISymbol property, INamedTypeSymbol attributeClassSymbol) 
            => property.GetAttributes()
                .FirstOrDefault(attribute 
                    => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, attributeClassSymbol));

    }
}
