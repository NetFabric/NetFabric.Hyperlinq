using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.GetSingle<TEnumerable, TEnumerator, TSource>();



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Option<TSource> Single<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.GetSingle<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Option<TSource> SingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.GetSingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);



        static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source
                .GetSingle<TEnumerable, TEnumerator, TSource>()
                .Select<TResult, TSelector>(selector);



        static Option<TResult> SingleAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source
                .GetSingle<TEnumerable, TEnumerator, TSource>()
                .Select<TResult, SingleSelector<TSource, TResult, TSelector>>(new SingleSelector<TSource, TResult, TSelector>(selector));

        struct SingleSelector<TSource, TResult, TSelector>
            : IFunction<TSource, TResult>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            TSelector selector;

            public SingleSelector(TSelector selector)
                => this.selector = selector;
                
            public TResult Invoke(TSource item) 
                => selector.Invoke(item, 0);
        }


        internal static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.GetSingle<TEnumerable, TEnumerator, TSource, TPredicate>(predicate).Select<TResult, TSelector>(selector);

        ////////////////////////////////
        // GetSingle 



        static Option<TSource> GetSingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var value = enumerator.Current;

                return enumerator.MoveNext() 
                    ? Option.None
                    : Option.Some(value);
            }
            return Option.None;
        }



        static Option<TSource> GetSingle<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate.Invoke(enumerator.Current))
                {
                    var value = enumerator.Current;

                    // found first, keep going until end or find second
                    while (enumerator.MoveNext())
                    {
                        if (predicate.Invoke(enumerator.Current))
                            return Option.None;
                    }

                    return Option.Some(value);
                }
            }
            return Option.None;
        }



        static Option<TSource> GetSingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate.Invoke(enumerator.Current, index))
                    {
                        var value = enumerator.Current;

                        // found first, keep going until end or find second
                        for (index++; enumerator.MoveNext(); index++)
                        {
                            if (predicate.Invoke(enumerator.Current, index))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            return Option.None;
        }
    }
}
