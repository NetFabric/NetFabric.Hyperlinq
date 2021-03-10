using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {
        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.ValueEnumerable<IReadOnlyList<TSource>, TSource> AsValueEnumerable<TEnumerator, TSource>(this IValueReadOnlyList<TSource, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyListExtensions.AsValueEnumerable<TSource>(source);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyListExtensions.ValueEnumerable<TList, TSource> AsValueEnumerable<TList, TEnumerator, TSource>(this TList source)
            where TList : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => ReadOnlyListExtensions.AsValueEnumerable<TList, TSource>(source);
    }
}