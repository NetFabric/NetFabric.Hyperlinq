using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace NetFabric.Hyperlinq.Generator
{
    public static class Extensions
    {
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

        public static INamespaceSymbol GetNamespace(this INamespaceSymbol root, params string[] name)
        {
            var current = root;
            for (var index = 0; index < name.Length; index++)
            {
                current = current.GetNamespaceMembers().FirstOrDefault(n => n.Name == name[index]);
                if (current is null)
                    return null;
            }
            return current;
        }

        public static bool SameAs(this IMethodSymbol method0, IMethodSymbol method1, int offset = 0)
            => method0.Name == method1.Name &&
                method0.Parameters.SameAs(method1.Parameters, offset);


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

        public static string AsParametersDeclarationString(this ImmutableArray<IParameterSymbol> parameters, IEnumerable<(string, string, bool)> genericsMapping)
            => parameters.Length switch
            {
                0 => string.Empty,
                1 => string.Empty,
                _ => parameters
                    .Skip(1)
                    .Select(parameter => {
                        var s = $"{parameter.Type.ToDisplayString(genericsMapping)} {parameter.Name}";
                        if (parameter.HasExplicitDefaultValue)
                        {
                            if (parameter.ExplicitDefaultValue is null)
                                s += " = default";
                            else
                                s += $" = {parameter.ExplicitDefaultValue.ToString()}";
                        }
                        return s;
                    })
                    .ToCommaSeparated(),
            };

        public static string AsParametersString(this IEnumerable<IParameterSymbol> parameters)
            => parameters.Any() ?
                parameters.Select(parameter => parameter.Name).ToCommaSeparated() :
                string.Empty;

        public static string AsTypeArgumentsString(this IEnumerable<ITypeSymbol> typeParameters, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, IEnumerable<(string, string, bool)> genericsMapping)
        {
            var result = new List<string>();
            foreach (var type in typeParameters)
            {
                switch(type.Name)
                {
                    case "TEnumerable":
                        result.Add(enumerableType.ToDisplayString());
                        break;
                    case "TEnumerator":
                        result.Add(enumeratorType.ToDisplayString());
                        break;
                    default:
                        result.Add(type.ToDisplayString(genericsMapping));
                        break;
                }
            }        

            return (result.Count == 0) ? 
                string.Empty : 
                $"<{result.ToCommaSeparated()}>";
        }

        public static string ToDisplayString(this ITypeSymbol type, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, IEnumerable<(string, string, bool)> genericsMapping)
        {
            if (type is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var valueEnumerableInterface = namedType.GetAllInterfaces()
                    .Where(@interface => @interface.Name == "IValueEnumerable" || @interface.Name == "IAsyncValueEnumerable")
                    .FirstOrDefault();
                if (valueEnumerableInterface is object)
                {
                    var displayName = namedType.ToDisplayString();
                    var classDisplayName = displayName.Substring(0, displayName.IndexOf('<'));
                    return $"{classDisplayName}{namedType.TypeArguments.AsTypeArgumentsString(enumerableType, enumeratorType, genericsMapping)}";
                }
            }
                
            return type.ToDisplayString(genericsMapping);
        }

        public static string ToDisplayString(this ITypeSymbol type, IEnumerable<(string, string, bool)> genericsMapping)
        {
            var result = type.ToDisplayString();
            if (genericsMapping is object)
            {
                foreach (var (from, to, _) in genericsMapping.Reverse())
                    result = result.Replace(from, to);
            }
            return result;
        }

        public static string ToDisplayString(this IMethodSymbol method, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, IEnumerable<(string, string, bool)> genericsMapping)
            => $"{method.Name}{method.TypeArguments.AsTypeArgumentsString(enumerableType, enumeratorType, genericsMapping)}";    

		static INamedTypeSymbol ignoreAttributeSymbol;
		static INamedTypeSymbol mappingAttributeSymbol;

        public static bool ShouldIgnore(this ISymbol symbol, Compilation compilation)
        {
            ignoreAttributeSymbol ??= compilation.GetTypeByMetadataName("NetFabric.Hyperlinq.GeneratorIgnoreAttribute");
            var attribute = symbol.FindAttributeFlattened(ignoreAttributeSymbol);
            return attribute is null 
                ? false 
                : (bool)attribute.ConstructorArguments[0].Value;
        }
        
        public static IEnumerable<(string, string, bool)> GetGenericMappings(this ITypeSymbol type, Compilation compilation)
        {
            mappingAttributeSymbol ??= compilation.GetTypeByMetadataName("NetFabric.Hyperlinq.GeneratorMappingAttribute");
            return type.GetAllAttributes()
                .Where(attribute => attribute.AttributeClass.Equals(mappingAttributeSymbol))
                .Select(attribute => (
                    (string)attribute.ConstructorArguments[0].Value, 
                    (string)attribute.ConstructorArguments[1].Value,
                    (bool)attribute.ConstructorArguments[2].Value));
        }

        public static (bool, string, bool) IsMapped(this ITypeSymbol type, IEnumerable<(string, string, bool)> genericsMapping)
        {
            foreach (var (from, to, isType) in genericsMapping)
            {
                if (type.Name == from)
                    return (true, to, isType);
            }
            return default;
        }

        public static string ToCommaSeparated(this IEnumerable<string> strings)
        {
            var result = new StringBuilder();
            using var enumerator = strings.GetEnumerator();
            if (enumerator.MoveNext())
            {
                _ = result.Append(enumerator.Current);
                while (enumerator.MoveNext())
                    _ = result
                        .Append(',')
                        .Append(' ')
                        .Append(enumerator.Current);
            }
            return result.ToString();
        }

        public static IEnumerable<(string Name, IEnumerable<string> Constraints)> ExtractMethodTypeArguments(INamedTypeSymbol extendedType, IMethodSymbol method, IEnumerable<(string, string, bool)> genericsMapping)
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

        static IEnumerable<(string Name, ITypeParameterSymbol TypeParameter)> ExtractTypeArgumentsFromType(ITypeSymbol type, HashSet<string> set, IEnumerable<(string, string, bool)> genericsMapping)
        {
            if (type is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                foreach (var typeArgument in namedType.TypeArguments)
                {
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

        public static IEnumerable<string> AsConstraintsStrings(this ITypeParameterSymbol parameter)
        {
            if (parameter.HasConstructorConstraint)
                yield return "new";
            if (parameter.HasReferenceTypeConstraint)
                yield return "class";
            if (parameter.HasValueTypeConstraint)
                yield return "struct";
            if (parameter.HasNotNullConstraint)
                yield return "notnull";
            foreach (var type in parameter.ConstraintTypes)
                yield return type.ToDisplayString();
        }
    }
}