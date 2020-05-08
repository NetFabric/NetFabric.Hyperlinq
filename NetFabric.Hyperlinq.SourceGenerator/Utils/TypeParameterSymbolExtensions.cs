using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class TypeParameterSymbolExtensions
    {
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

            var constraintTypes = parameter.ConstraintTypes;
            for (var index = 0; index < constraintTypes.Length; index++)
                yield return constraintTypes[index].ToDisplayString();
        }
    }
}
