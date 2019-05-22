using System;

namespace NetFabric.Hyperlinq
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class IgnoreAttribute : Attribute
    {
        public bool Value { get; private set; }

        public IgnoreAttribute(bool value = true)
        {
            Value = value;
        }
    }
}