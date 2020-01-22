using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyList.ToList<TSource>(source);

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyList.ToList<TSource>(source, skipCount, takeCount);

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyList.ToList<TSource>(source, predicate, skipCount, takeCount);

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyList.ToList<TSource>(source, predicate, skipCount, takeCount);
    }
}
