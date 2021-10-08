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
        {
            return source switch
            {
                {Count: 0} => Option.None,
                _ => GetFirst(source)
            };

            static Option<TSource> GetFirst(TEnumerable source)
            {
                using var enumerator = source.GetEnumerator();
                _ = enumerator.MoveNext();
                return Option.Some(enumerator.Current);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> First<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool> 
            => source switch
            {
                {Count: 0} => Option.None,
                _ => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> FirstAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool> 
            => source switch
            {
                {Count: 0} => Option.None,
                _ => ValueEnumerableExtensions.FirstAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                {Count: 0} => Option.None,
                _ => GetFirst(source, selector)
            };

            static Option<TResult> GetFirst(TEnumerable source, TSelector selector)
            {
                using var enumerator = source.GetEnumerator();
                _ = enumerator.MoveNext();
                return Option.Some(selector.Invoke(enumerator.Current));
            }
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> FirstAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source switch
            {
                {Count: 0} => Option.None,
                _ => GetFirst(source, selector)
            };

            static Option<TResult> GetFirst(TEnumerable source, TSelector selector)
            {
                using var enumerator = source.GetEnumerator();
                _ = enumerator.MoveNext();
                return Option.Some(selector.Invoke(enumerator.Current, 0));
            }
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool> 
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                {Count: 0} => Option.None,
                _ => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector)
            };
    }
}
