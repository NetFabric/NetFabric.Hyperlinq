using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        public static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => index < source.Count
                ? ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource>(source, index)
                : Option.None;
        
        static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => index < source.Count
                ? ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, index, selector)
                : Option.None;

        
        static Option<TResult> ElementAtAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => index < source.Count
                ? ValueEnumerableExtensions.ElementAtAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, index, selector)
                : Option.None;
    }
}
