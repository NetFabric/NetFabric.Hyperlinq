using System;

namespace NetFabric.Hyperlinq
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class GenericsMappingAttribute : Attribute
    {
        public string From { get; }
        public string To { get; }

        public GenericsMappingAttribute(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}