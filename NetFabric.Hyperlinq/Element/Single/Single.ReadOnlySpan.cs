using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static Option<TSource> Single<TSource>(this ReadOnlySpan<TSource> source)
        {
            switch (source.Length)
            {
                case 0:
                    return Option.None;
                case 1:
                    return Option.Some(source[0]);
                default:
                    return Option.None;
            }
        }

        [Pure]
        static Option<TSource> Single<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate(source[index]))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }

        [Pure]
        static Option<TSource> Single<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate(source[index], index))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> Single<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[0])),
                _ => Option.None,
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> Single<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[0], 0)),
                _ => Option.None,
            };

        [Pure]
        static Option<TResult> Single<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate(source[index]))
                            return Option.None;
                    }

                    return Option.Some(selector(first));
                }
            }
            return Option.None;
        }
    }
}
