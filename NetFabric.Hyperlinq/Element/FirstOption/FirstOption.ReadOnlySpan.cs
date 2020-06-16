using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> FirstOption<TSource>(this ReadOnlySpan<TSource> source) 
            => source.Length == 0 
                ? Option.None
                : Option.Some(source[0]);

        
        static Option<TSource> FirstOption<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return Option.Some(source[index]);
            }
            return Option.None;
        }

        
        static Option<TSource> FirstOption<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    return Option.Some(source[index]);
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> FirstOption<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[0])),
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> FirstOption<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[0], 0)),
            };

        
        static Option<TResult> FirstOption<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
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
