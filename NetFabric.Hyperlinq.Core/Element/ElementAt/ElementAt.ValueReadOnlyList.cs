using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source switch
            {
                {Count: 0} => Option.None,
                _ => index < source.Count
                    ? ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource>(source, index)
                    : Option.None
            };
    }
}
