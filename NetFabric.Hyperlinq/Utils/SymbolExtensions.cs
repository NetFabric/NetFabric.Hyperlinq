using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class SymbolExtensions
    {
        public static bool IsPublic(this ISymbol typeSymbol) 
            => typeSymbol.DeclaredAccessibility == Accessibility.Public;

        public static ImmutableArray<GeneratorMappingAttribute> GetGenericsMappings(this ISymbol type, CompilationContext compilation)
        {
            var attributes = type.GetAttributes()
                .Where(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, compilation.GeneratorMappingAttribute))
                .Select(attribute => new GeneratorMappingAttribute(
                    (string)attribute.ConstructorArguments[0].Value!,
                    (string)attribute.ConstructorArguments[1].Value!,
                    (bool)attribute.ConstructorArguments[2].Value!));

            return ImmutableArray.CreateRange(attributes);
        }

        public static GeneratorBindingsAttribute? GetBindingsAttribute(this ISymbol type, CompilationContext compilation)
        {
            var attribute = type.GetAttributes()
                .FirstOrDefault(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, compilation.GeneratorBindingsAttribute));

            return attribute switch
            {
                null => null,
                _ => new GeneratorBindingsAttribute(
                    (string)attribute.ConstructorArguments[0].Value!,
                    (string)attribute.ConstructorArguments[1].Value!,
                    (string?)attribute.ConstructorArguments[2].Value,
                    (string?)attribute.ConstructorArguments[3].Value,
                    (string?)attribute.ConstructorArguments[4].Value,
                    (string?)attribute.ConstructorArguments[5].Value,
                    (string?)attribute.ConstructorArguments[6].Value)
            };
        }

        public static GeneratorIgnoreAttribute? GetIgnoreAttribute(this ISymbol type, CompilationContext compilation)
        {
            var attribute = type.GetAttributes()
                .FirstOrDefault(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, compilation.GeneratorIgnoreAttribute));

            return attribute switch
            {
                null => null,
                _ => new GeneratorIgnoreAttribute((bool)attribute.ConstructorArguments[0].Value!)
            };
        }


        public static bool ShouldIgnore(this ISymbol symbol, CompilationContext context)
            => symbol.GetIgnoreAttribute(context)?.Value ?? false;


        public static bool ShouldNotIgnore(this ISymbol symbol, CompilationContext context)
        {
            var attribute = symbol.GetIgnoreAttribute(context);
            return attribute switch
            {
                null => false,
                _ => !attribute.Value
            };
        }

        public static (bool, string, bool) IsMapped(this ISymbol type, ImmutableArray<GeneratorMappingAttribute> genericsMapping)
        {
            foreach (var mapping in genericsMapping)
            {
                if (type.Name == mapping.From)
                    return (true, mapping.To, mapping.IsType);
            }
            return default;
        }
    }
}
