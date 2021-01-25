using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class TypeSymbolExtensions
    {
        public static bool IsInterface(this ITypeSymbol typeSymbol)
            => typeSymbol.TypeKind == TypeKind.Interface;

        public static IEnumerable<INamedTypeSymbol> GetAllInterfaces(this ITypeSymbol typeSymbol, bool includeCurrent = true)
        {
            if (includeCurrent && typeSymbol.IsInterface())             
                yield return (INamedTypeSymbol)typeSymbol;

#pragma warning disable IDE0007 // Use implicit type
            ITypeSymbol? currentTypeSymbol = typeSymbol;
#pragma warning restore IDE0007 // Use implicit type
            do
            {
                var interfaces = currentTypeSymbol.Interfaces;
                for (var index = 0; index < interfaces.Length; index++)
                {
                    var @interface = interfaces[index];

                    yield return @interface;

                    foreach (var innerInterface in @interface.GetAllInterfaces())
                        yield return innerInterface;
                }

                currentTypeSymbol = currentTypeSymbol.BaseType;

            } while (currentTypeSymbol is not null && currentTypeSymbol.SpecialType != SpecialType.System_Object);
        }

        public static ImmutableArray<(string, string, bool)> GetGenericsMappings(this ISymbol type, Compilation compilation)
        {
            var mappingAttributeSymbol = compilation.GetTypeByMetadataName("NetFabric.Hyperlinq.GeneratorMappingAttribute");
            var mappings = type.GetAttributes()
                .Where(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, mappingAttributeSymbol))
                .Select(attribute => (
                    (string)attribute.ConstructorArguments[0].Value!,
                    (string)attribute.ConstructorArguments[1].Value!,
                    (bool)attribute.ConstructorArguments[2].Value!));

            return ImmutableArray.CreateRange(mappings);
        }

        public static string ToDisplayString(this ITypeSymbol type, ImmutableArray<(string, string, bool)> genericsMapping)
            => type.ToDisplayString().ApplyMappings(genericsMapping, out _);

        static IEnumerable<ITypeParameterSymbol> GetTypeArguments(ITypeSymbol typeSymbol)
        {
            if (typeSymbol is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var typeArguments = namedType.TypeArguments;
                for (var index = 0; index < typeArguments.Length; index++)
                {
                    var typeArgument = typeArguments[index];
                    if (typeArgument is ITypeParameterSymbol typeParameter)
                        yield return typeParameter;
                }
            }
        }

        static IEnumerable<(string Name, ITypeParameterSymbol TypeParameter)> MapTypeParameters(IEnumerable<ITypeParameterSymbol> typeParameters, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            var set = new HashSet<string>();

            foreach (var typeParameter in typeParameters)
            {
                var (isMapped, mappedTo, _) = typeParameter.IsMapped(genericsMapping);
                if (isMapped)
                {
                    if (set.Add(mappedTo))
                        yield return (mappedTo, typeParameter);
                }
                else
                {
                    var displayString = typeParameter.ToDisplayString();
                    if (set.Add(displayString))
                    {
                        yield return (displayString, typeParameter);
                    }
                }
            }
        }

        public static IEnumerable<(string Name, string Constraints)> MappedTypeArguments(this ITypeSymbol type, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            var methodParameters = GetTypeArguments(type);
            return MapTypeParameters(methodParameters, genericsMapping)
                .Select(typeArgument => (typeArgument.Name, typeArgument.TypeParameter.AsConstraintsStrings(genericsMapping).ToCommaSeparated()));
        }

        static (bool, string, bool) IsMapped(this ITypeSymbol type, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            foreach (var (from, to, isConcreteType) in genericsMapping)
            {
                if (type.Name == from)
                    return (true, to, isConcreteType);
            }
            return default;
        }
    }
}
