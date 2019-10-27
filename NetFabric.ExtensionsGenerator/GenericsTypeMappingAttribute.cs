using System;

namespace NetFabric
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class GenericsTypeMappingAttribute : Attribute
    {
        public string From { get; }
        public Type To { get; }

        public GenericsTypeMappingAttribute(string from, Type to)
        {
            From = from;
            To = to;
        }
    }
}