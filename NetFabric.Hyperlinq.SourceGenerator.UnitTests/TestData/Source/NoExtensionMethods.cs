using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public class NotStaticClass
    {
    }

    static class NotPublicStaticClass
    {
        public static void ExtensionMethod<TEnumerable, TEnumerator, TSource>(this TEnumerable _)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        { }
    }

    public static class NoExtensionMethods
    {
        public static void NotConstrainedExtensionMethod(this ArraySegment<int> _) { }

        public static void NotExtensionMethod<TEnumerable, TEnumerator, TSource>(TEnumerable _)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        { }

        static void NotPublicExtensionMethod<TEnumerable, TEnumerator, TSource>(this TEnumerable _)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        { }

        [GeneratorIgnore]
        public static void IgnoredExtensionMethod<TEnumerable, TEnumerator, TSource>(this TEnumerable _)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        { }
    }

}
