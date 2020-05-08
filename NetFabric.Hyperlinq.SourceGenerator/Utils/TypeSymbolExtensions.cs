using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class TypeSymbolExtensions
    {
        static INamedTypeSymbol? mappingAttributeSymbol;

        static INamedTypeSymbol GetGeneratorMappingAttributeSymbol(Compilation compilation)
            => mappingAttributeSymbol ??= compilation.GetTypeByMetadataName("NetFabric.Hyperlinq.GeneratorMappingAttribute")!;

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

            } while (currentTypeSymbol is object && currentTypeSymbol.SpecialType != SpecialType.System_Object);
        }

        public static bool Contains(this ITypeSymbol type, IMethodSymbol method)
            => type
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Any(typeMethod => typeMethod.SameAs(method));

        public static bool ContainsExtension(this ITypeSymbol type, IMethodSymbol method)
            => type
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Any(typeMethod =>
                    typeMethod.IsExtensionMethod &&
                    typeMethod.SameAs(method, 1));

        public static ImmutableArray<(string, string, bool)> GetGenericMappings(this ITypeSymbol type, Compilation compilation)
        {
            var mappingAttributeSymbol = GetGeneratorMappingAttributeSymbol(compilation);
            var mappings = type.GetAttributes()
                .Where(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, mappingAttributeSymbol))
                .Select(attribute => (
                    (string)attribute.ConstructorArguments[0].Value!,
                    (string)attribute.ConstructorArguments[1].Value!,
                    (bool)attribute.ConstructorArguments[2].Value!));

            return ImmutableArray.CreateRange(mappings);
        }

        public static string ToDisplayString(this ITypeSymbol type, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            var result = type.ToDisplayString();
            foreach (var (from, to, _) in genericsMapping.Reverse())
                result = result.Replace(from, to);
            return result;
        }

        public static string ToDisplayString(this ITypeSymbol type, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            if (type is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var displayName = namedType.ToDisplayString();
                var classDisplayName = displayName.Substring(0, displayName.IndexOf('<'));

                if (namedType.GetAllInterfaces()
                    .Any(@interface =>
                        @interface.Name == "IReadOnlyList" ||
                        @interface.Name == "IValueEnumerable" ||
                        @interface.Name == "IAsyncValueEnumerable"))
                {
                    return $"{classDisplayName}{namedType.TypeArguments.AsTypeArgumentsString(enumerableType, enumeratorType, genericsMapping)}";
                }
            }

            return type.ToDisplayString(genericsMapping);
        }

        public static IEnumerable<(string Name, ITypeParameterSymbol TypeParameter)> ExtractTypeArgumentsFromType(ITypeSymbol typeSymbol, HashSet<string> set, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            if (typeSymbol is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var typeArguments = namedType.TypeArguments;
                for (var index = 0; index < typeArguments.Length; index++)
                {
                    var typeArgument = typeArguments[index];
                    if (typeArgument is ITypeParameterSymbol typeParameter)
                    {
                        var (isMapped, mappedTo, isMappedToType) = typeParameter.IsMapped(genericsMapping);
                        if (!isMappedToType)
                        {
                            var displayString = typeParameter.ToDisplayString();
                            if (set.Add(displayString))
                            {
                                yield return (displayString, typeParameter);

                                if (isMapped && set.Add(mappedTo))
                                    yield return (mappedTo, typeParameter);
                            }
                        }
                    }
                }
            }
        }

        public static IEnumerable<(string Name, IEnumerable<string> Constraints)> ExtractMethodTypeArguments(this ITypeSymbol extendedType, IMethodSymbol method, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            var set = new HashSet<string>();

            // get the type arguments list from the extension method parameters
            var parameteresTypeArguments =
                ExtractTypeArgumentsFromType(extendedType, set, genericsMapping)
                .Concat(method.Parameters.SelectMany(parameter => ExtractTypeArgumentsFromType(parameter.Type, set, genericsMapping)))
                .ToList();

            // get the type arguments list from the contraints
            var constraintsTypeArguments = parameteresTypeArguments
                .SelectMany(typeArgument => typeArgument.TypeParameter.ConstraintTypes)
                .SelectMany(type => ExtractTypeArgumentsFromType(type, set, genericsMapping))
                .ToList();

            return parameteresTypeArguments.Concat(constraintsTypeArguments)
                .Select(typeArgument => (typeArgument.Name, typeArgument.TypeParameter.AsConstraintsStrings()));
        }

        static (bool, string, bool) IsMapped(this ITypeSymbol type, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            foreach (var (from, to, isType) in genericsMapping)
            {
                if (type.Name == from)
                    return (true, to, isType);
            }
            return default;
        }

        public static string AsTypeArgumentsString(this ImmutableArray<ITypeSymbol> typeParameters, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, ImmutableArray<(string, string, bool)> genericsMapping)
        {
            var result = new List<string>();
            for (var index = 0; index < typeParameters.Length; index++)
            {
                switch (typeParameters[index].Name)
                {
                    case "TEnumerable":
                    case "TList":
                        result.Add(enumerableType.ToDisplayString());
                        break;
                    case "TEnumerator":
                        if (enumeratorType is object)
                            result.Add(enumeratorType.ToDisplayString());
                        break;
                    default:
                        result.Add(typeParameters[index].ToDisplayString(genericsMapping));
                        break;
                }
            }

            return (result.Count == 0) 
                ? string.Empty 
                : $"<{result.ToCommaSeparated()}>";
        }
    }
}
