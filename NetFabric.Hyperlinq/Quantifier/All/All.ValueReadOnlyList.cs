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
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count);
        }

        [Pure]
        static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TEnumerable, TEnumerator, TSource>(source, predicate, 0, source.Count);
        }

        [Pure]
        static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (!predicate(source[index], index))
                    return false;
            }
            return true;
        }
    }
}

