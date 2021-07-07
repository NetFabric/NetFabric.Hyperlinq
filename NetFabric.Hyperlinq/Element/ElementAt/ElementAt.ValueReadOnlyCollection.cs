using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source switch
            {
                {Count: 0} => Option.None,
                _ => ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, index, predicate)
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> ElementAtAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source switch
            {
                {Count: 0} => Option.None,
                _ => ValueEnumerableExtensions.ElementAtAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, index, predicate)
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                {Count: 0} => Option.None,
                _ => index < source.Count
                    ? ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, index, selector)
                    : Option.None
            };



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAtAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source switch
            {
                {Count: 0} => Option.None,
                _ => index < source.Count
                    ? ValueEnumerableExtensions.ElementAtAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, index, selector)
                    : Option.None
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, int index, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                {Count: 0} => Option.None,
                _ => ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, index, predicate, selector)
            };
    }
}
