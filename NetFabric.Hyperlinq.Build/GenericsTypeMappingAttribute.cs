using System;

namespace NetFabric.Hyperlinq
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class GenericsTypeMappingAttribute : Attribute
    {
        public string From { get; private set; }
        public Type To { get; private set; }

        public GenericsTypeMappingAttribute(string from, Type to)
        {
            From = from;
            To = to;
        }
    }
}