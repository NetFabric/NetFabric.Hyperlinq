using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this ReadOnlySpan<TSource> source) 
            => source.Length == 0 
                ? Option.None
                : Option.Some(source[0]);

        
        static Option<TSource> First<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                    return Option.Some(source[index]);
            }
            return Option.None;
        }

        
        static Option<TSource> FirstAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index], index))
                    return Option.Some(source[index]);
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> First<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[0])),
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> First<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[0], 0)),
            };

        
        static Option<TResult?> First<TSource, TResult, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                    return Option.Some(selector(source[index]));
            }
            return Option.None;
        }
    }
}
