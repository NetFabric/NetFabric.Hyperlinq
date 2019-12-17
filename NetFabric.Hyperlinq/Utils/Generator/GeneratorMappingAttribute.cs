using System;

namespace NetFabric.Hyperlinq
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GeneratorMappingAttribute : Attribute
    {
        public string From { get; }
        public string To { get; }
        public bool IsType { get; }

        public GeneratorMappingAttribute(string from, string to, bool isType = false)
        {
            From = from;
            To = to;
            IsType = isType;
        }
    }
}