using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var item = TryElementAt<TEnumerable, TEnumerator, TSource>(source, index);
            return item.HasValue ? item.Value : ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var item = TryElementAt<TEnumerable, TEnumerator, TSource>(source, index);
            return item.HasValue ? item.Value : default;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<TSource> TryElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0 && index < source.Count)
            {
                var current = 0;
                foreach (var item in source)
                {
                    if (current == index)
                        return new Maybe<TSource>(item);

                    checked { current++; }
                }
            }

            return default;
        }
    }
}
