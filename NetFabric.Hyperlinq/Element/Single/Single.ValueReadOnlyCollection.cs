using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        public static Option<TSource> Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count switch
            {
                1 => ValueEnumerableExtensions.Single<TEnumerable, TEnumerator, TSource>(source),
                _ => Option.None
            };

        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count switch
            {
                1 => ValueEnumerableExtensions.Single<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector),
                _ => Option.None
            };

        
        static Option<TResult> SingleAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Count switch
            {
                1 => ValueEnumerableExtensions.SingleAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector),
                _ => Option.None
            };
    }
}
