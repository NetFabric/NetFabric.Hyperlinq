using System;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GeneratorMappingAttribute : Attribute
    {
        public string From { get; }
        public string To { get; }
        public bool IsConcreteType { get; }

        public GeneratorMappingAttribute(string from, string to, bool isConcreteType = false)
            => (From, To, IsConcreteType) = (from, to , isConcreteType);
    }
}