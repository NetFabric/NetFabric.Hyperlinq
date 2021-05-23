using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ExtensionMethods
    {
        public static void NotConstrainedExtensionMethod(this ArraySegment<int> _) { }

        static void NotIgnoredExtensionMethod<TEnumerable, TEnumerator, TSource>(this TEnumerable _)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        { }

        public static void PublicExtensionMethod<TEnumerable, TEnumerator, TSource>(this TEnumerable _)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        { }
    }

}
