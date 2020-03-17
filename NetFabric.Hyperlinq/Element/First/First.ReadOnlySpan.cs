using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this ReadOnlySpan<TSource> source) 
            => source.Length == 0 
                ? Option.None
                : Option.Some(source[0]);

        [Pure]
        static Option<TSource> First<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return Option.Some(source[index]);
            }
            return Option.None;
        }

        [Pure]
        static Option<TSource> First<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    return Option.Some(source[index]);
            }
            return Option.None;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[0])),
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[0], 0)),
            };

        [Pure]
        static Option<TResult> First<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return Option.Some(selector(source[index]));
            }
            return Option.None;
        }
    }
}
