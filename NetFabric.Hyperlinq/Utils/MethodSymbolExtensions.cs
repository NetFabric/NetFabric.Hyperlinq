using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    struct MethodInfo
    {
        public string ContainingType { get; set; }
        public ITypeSymbol ReturnType { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<(string Name, string Constraints, bool IsConcreteType)> TypeParameters { get; set; }
        public IReadOnlyList<(string Name, string Type, string? DefaultValue)> Parameters { get; set; }
        public ImmutableArray<GeneratorMappingAttribute> GenericsMapping { get; set; }
    }

    static class MethodSymbolExtensions
    {
        public static IEnumerable<ITypeParameterSymbol> GetTypeParameterSymbols(this IMethodSymbol methodSymbol)
        {
            var typeArguments = methodSymbol.TypeArguments;
            for (var index = 0; index < typeArguments.Length; index++)
            {
                var typeArgument = typeArguments[index];
                if (typeArgument is ITypeParameterSymbol typeParameter)
                    yield return typeParameter;
            }
        }

        public static MethodInfo GetInfo(this IMethodSymbol method, CompilationContext context, int skip = default)
        {
            try
            {
                return new MethodInfo
                {
                    ContainingType = method.ContainingType.ToDisplayString(),
                    ReturnType = method.ReturnType,
                    Name = method.Name,
                    Parameters = method.Parameters
                        .Skip(skip)
                        .Select(parameter => (parameter.Name, parameter.Type.ToDisplayString(), parameter.HasExplicitDefaultValue ? parameter.ExplicitDefaultValue is null ? "default" : ToDisplayString(parameter.ExplicitDefaultValue) : default))
                        .ToArray(),
                    TypeParameters =
                        method.ContainingType.TypeParameters.Concat(method.TypeParameters)
                        .Select(parameter => (parameter.ToDisplayString(), parameter.AsConstraintsStrings().ToCommaSeparated(), false))
                        .ToArray(),
                    GenericsMapping = method.GetGenericsMappings(context),
                };
            }
            catch (Exception ex)
            {
                throw;
            }

            static string ToDisplayString(object? obj)
                => obj switch
                {
                    null => "<NULL>",
                    true => "true",
                    false => "false",
                    _ => obj.ToString()
                };
        }

        public static MethodInfo ApplyMappings(this MethodInfo method, ImmutableArray<GeneratorMappingAttribute> typeGenericsMapping)
        {
            var genericsMapping = typeGenericsMapping.AddRange(method.GenericsMapping);
            if (genericsMapping.IsDefault)
                return method;

            var result = new MethodInfo
            {
                ContainingType = method.ContainingType.ApplyMappings(genericsMapping, out _),
                ReturnType = method.ReturnType,
                Name = method.Name,
                Parameters = method.Parameters
                    .Select(parameter => (parameter.Name, parameter.Type.ApplyMappings(genericsMapping, out _), parameter.DefaultValue))
                    .ToArray(),
                GenericsMapping = method.GenericsMapping,
            };

            var typeParameters = new List<(string, string, bool)>();
            foreach (var (Name, Constraints, _) in method.TypeParameters)
            {
                var mapped = Name.ApplyMappings(genericsMapping, out var isConcreteType);
                typeParameters.Add((mapped, Constraints.ApplyMappings(genericsMapping, out _), isConcreteType));
            }

            result.TypeParameters = typeParameters;
            return result;
        }

        public static bool IsOverload(this MethodInfo method0, MethodInfo method1)
        {
            if (method0.Name != method1.Name)
                return false;

            var parameters0 = method0.Parameters;
            var parameters1 = method1.Parameters;

            if (parameters0.Count != parameters1.Count)
                return false;

            for (var index = 0; index < parameters0.Count; index++)
            {
                var (_, type0, _) = parameters0[index];
                var (_, type1, _) = parameters1[index];

                // check if parameter type is defined by contraints
                var constraints0 = method0.TypeParameters.FirstOrDefault(typeParameter => type0 == typeParameter.Name).Constraints;
                var constraints1 = method1.TypeParameters.FirstOrDefault(typeParameter => type1 == typeParameter.Name).Constraints;
                if (constraints0 is null or { Length: 0 })
                {
                    if (constraints1 is not null and { Length: not 0 })
                        return false;

                    if (type0 != type1)
                        return false;
                }
                else
                {
                    if (constraints1 is null or { Length: 0 })
                        return false;

                    return constraints0 == constraints1;
                }
            }
            return true;
        }
    }
}
