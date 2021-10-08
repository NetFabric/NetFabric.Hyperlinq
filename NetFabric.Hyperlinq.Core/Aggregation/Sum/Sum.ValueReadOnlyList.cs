using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSum Sum<TEnumerable, TEnumerator, TSource, TSum>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSum : struct
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, TSum>(source);
    }
}

