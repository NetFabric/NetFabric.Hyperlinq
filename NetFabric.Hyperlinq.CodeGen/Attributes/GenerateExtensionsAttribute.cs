using System;

namespace NetFabric.Hyperlinq
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class GenerateExtensionsAttribute : Attribute
    {
        public bool Value { get; }

        public GenerateExtensionsAttribute(bool value = true)
        {
            Value = value;
        }
    }
}