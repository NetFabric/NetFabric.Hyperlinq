using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count is not 0 && ValueEnumerableExtensions.Contains<TEnumerable, TEnumerator, TSource>(source, value, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool Contains<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TResult value, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count is not 0 && ValueEnumerableExtensions.Contains<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, value, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool ContainsAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TResult value, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count is not 0 && ValueEnumerableExtensions.ContainsAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, value, selector);

    }
}
