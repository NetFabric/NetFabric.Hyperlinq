using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this Span<TSource> source, int index) 
            => index < 0 || index >= source.Length ? 
                Option.None : 
                Option.Some(source[index]);

        [Pure]
        static Option<TSource> ElementAt<TSource>(this Span<TSource> source, int index, Predicate<TSource> predicate) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        [Pure]
        static Option<TSource> ElementAt<TSource>(this Span<TSource> source, int index, PredicateAt<TSource> predicate) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item, sourceIndex) && index-- == 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TSource, TResult>(this Span<TSource> source, int index, Selector<TSource, TResult> selector) 
            => index < 0 || index >= source.Length ? 
                Option.None : 
                Option.Some(selector(source[index]));

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> ElementAt<TSource, TResult>(this Span<TSource> source, int index, SelectorAt<TSource, TResult> selector) 
            => index < 0 || index >= source.Length ? 
                Option.None : 
                Option.Some(selector(source[index], index));

        [Pure]
        static Option<TResult> ElementAt<TSource, TResult>(this Span<TSource> source, int index, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate(item) && index-- == 0)
                        return Option.Some(selector(item));
                }
            }
            return Option.None;
        }
    }
}
