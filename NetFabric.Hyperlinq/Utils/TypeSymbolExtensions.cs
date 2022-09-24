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
            // ReSharper disable once SuggestVarOrType_SimpleTypes
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

        public static string ToDisplayString(this ITypeSymbol type, ImmutableArray<GeneratorMappingAttribute> genericsMapping)
            => type.ToDisplayString().ApplyMappings(genericsMapping, out _);

        static IEnumerable<ITypeParameterSymbol> GetTypeArguments(ITypeSymbol typeSymbol)
        {
            if (typeSymbol is INamedTypeSymbol {IsGenericType: true} namedType)
            {
                var typeArguments = namedType.TypeArguments;
                foreach (var typeArgument in typeArguments)
                {
                    if (typeArgument is ITypeParameterSymbol typeParameter)
                        yield return typeParameter;
                }
            }
        }

        static IEnumerable<(string Name, ITypeParameterSymbol TypeParameter)> MapTypeParameters(IEnumerable<ITypeParameterSymbol> typeParameters, ImmutableArray<GeneratorMappingAttribute> genericsMapping)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
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

        public static IEnumerable<(string Name, string Constraints)> MappedTypeArguments(this ITypeSymbol type, ImmutableArray<GeneratorMappingAttribute> genericsMapping)
        {
            var methodParameters = GetTypeArguments(type);
            return MapTypeParameters(methodParameters, genericsMapping)
                .Select(typeArgument => (typeArgument.Name, typeArgument.TypeParameter.AsConstraintsStrings(genericsMapping).ToCommaSeparated()));
        }
    }
}
