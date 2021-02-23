using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source switch
            {
                { Count: 0 } => Option.None,
                _ => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource>(source)
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Count: 0 } => Option.None,
                _ => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector)
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> FirstAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source switch
            {
                { Count: 0 } => Option.None,
                _ => ValueEnumerableExtensions.FirstAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector)
            };
    }
}
