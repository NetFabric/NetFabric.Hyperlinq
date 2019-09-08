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
        public static TSource ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var item = TryElementAt<TEnumerable, TEnumerator, TSource>(source, index, 0, source.Count);
            return item.HasValue ? item.Value : ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var item = TryElementAt<TEnumerable, TEnumerator, TSource>(source, index, skipCount, takeCount);
            return item.HasValue ? item.Value : ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var item = TryElementAt<TEnumerable, TEnumerator, TSource>(source, index, 0, source.Count);
            return item.HasValue ? item.Value : default;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var item = TryElementAt<TEnumerable, TEnumerator, TSource>(source, index, skipCount, takeCount);
            return item.HasValue ? item.Value : default;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<TSource> TryElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryElementAt<TEnumerable, TEnumerator, TSource>(source, index, 0, source.Count);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Maybe<TSource> TryElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index < 0 || skipCount > source.Count || index >= takeCount)
                return default;

            return new Maybe<TSource>(source[index + skipCount]);
        }
    }
}
