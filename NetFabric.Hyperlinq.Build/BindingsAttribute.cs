using System;

namespace NetFabric.Hyperlinq
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class BindingsAttribute : Attribute
    {
        public Type Enumerable { get; private set; }
        public Type Enumerator { get; private set; }
        public Type Element { get; private set; }
        public string[] Generics { get; private set; }

        public BindingsAttribute(Type enumerable, Type enumerator, Type element, params string[] generics)
        {
            Enumerable = enumerable;
            Enumerator = enumerator;
            Element = element;
            Generics = generics;
        }
    }
}