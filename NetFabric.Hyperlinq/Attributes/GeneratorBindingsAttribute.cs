using System;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Struct)]
    public sealed class GeneratorBindingsAttribute 
        : Attribute
    {
        public string Source { get; }
        public string ElementType { get; }
        public string? SourceImplements { get; }
        public string? EnumerableType { get; }
        public string? EnumeratorType { get; }
        public string? ExtraTypeParameters { get; }
        public string? ExtraParameters { get; }

        public GeneratorBindingsAttribute(
                string source = "this", 
                string elementType = "TSource",
                string? sourceImplements = default,
                string? enumerableType = default, 
                string? enumeratorType = default, 
                string? extraTypeParameters = default,
                string? extraParameters = default
            )
            => (Source, ElementType, SourceImplements, EnumerableType, EnumeratorType, ExtraTypeParameters, ExtraParameters) 
                = (source, elementType, sourceImplements, enumerableType, enumeratorType, extraTypeParameters, extraParameters);
    }
}