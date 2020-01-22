using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyList.ToArray(source, 0, source.Count);

        [Pure]
        static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyList.ToArray(source, skipCount, takeCount);
    }
}
