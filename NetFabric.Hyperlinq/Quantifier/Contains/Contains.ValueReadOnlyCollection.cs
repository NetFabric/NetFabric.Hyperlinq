using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count != 0 && ValueEnumerableExtensions.Contains<TEnumerable, TEnumerator, TSource>(source, value, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count != 0 && ValueEnumerableExtensions.Contains<TEnumerable, TEnumerator, TSource, TResult>(source, value, selector);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count != 0 && ValueEnumerableExtensions.Contains<TEnumerable, TEnumerator, TSource, TResult>(source, value, selector);

    }
}
