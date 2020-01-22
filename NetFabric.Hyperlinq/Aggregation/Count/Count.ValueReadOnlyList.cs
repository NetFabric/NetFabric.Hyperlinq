using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var count = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        [Pure]
        internal static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        [Pure]
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var count = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var result = predicate(source[index], index);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        [Pure]
        internal static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var result = predicate(source[index], index);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }
    }
}

