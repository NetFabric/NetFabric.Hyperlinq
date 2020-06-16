using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> FirstOption<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count == 0 
                ? Option.None
                : ValueEnumerableExtensions.FirstOption<TEnumerable, TEnumerator, TSource>(source);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> FirstOption<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count == 0
                ? Option.None
                : ValueEnumerableExtensions.FirstOption<TEnumerable, TEnumerator, TSource, TResult>(source, selector);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> FirstOption<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count == 0
                ? Option.None
                : ValueEnumerableExtensions.FirstOption<TEnumerable, TEnumerator, TSource, TResult>(source, selector);
    }
}
