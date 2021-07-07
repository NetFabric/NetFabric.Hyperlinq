using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static Option<TSource> Single<TSource>(this ReadOnlySpan<TSource> source) 
            => source switch
            {
                { Length: 1 } => Option.Some(source[0]),
                _ => Option.None,
            };

        static Option<TSource> Single<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                {
                    var first = source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate.Invoke(source[index]))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }


        static Option<TSource> SingleAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index], index))
                {
                    var first = source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate.Invoke(source[index], index))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }


        static Option<TResult> Single<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Length: 1 } => Option.Some(selector.Invoke(source[0])),
                _ => Option.None,
            };


        static Option<TResult> SingleAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source switch
            {
                { Length: 1 } => Option.Some(selector.Invoke(source[0], 0)),
                _ => Option.None,
            };



        static Option<TResult> Single<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                {
                    var first = source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate.Invoke(source[index]))
                            return Option.None;
                    }

                    return Option.Some(selector.Invoke(first));
                }
            }
            return Option.None;
        }
    }
}
