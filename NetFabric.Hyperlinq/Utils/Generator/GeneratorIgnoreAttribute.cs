using System;

namespace NetFabric.Hyperlinq
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class GeneratorIgnoreAttribute : Attribute
    {
        public bool Value { get; }

        public GeneratorIgnoreAttribute(bool value = true)
            => Value = value;
    }
}