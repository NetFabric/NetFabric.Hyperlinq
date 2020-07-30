using System;
using System.Reflection;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class AttributeExtensions
    {
        public static TAttribute GetCustomAttribute<TAttribute>(Assembly assembly) where TAttribute : Attribute
            => (TAttribute)Attribute.GetCustomAttribute(assembly, typeof(TAttribute));
    }
}
