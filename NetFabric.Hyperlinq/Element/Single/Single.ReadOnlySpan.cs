using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        public static Option<TSource> Single<TSource>(this ReadOnlySpan<TSource> source) 
            => source.Length switch
            {
                0 => Option.None,
                1 => Option.Some(source[0]),
                _ => Option.None,
            };

        static Option<TSource> Single<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                {
                    ref readonly var first = ref source[index];

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
            where TPredicate : struct, IPredicateAt<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index], index))
                {
                    ref readonly var first = ref source[index];

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

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> Single<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[0])),
                _ => Option.None,
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> Single<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[0], 0)),
                _ => Option.None,
            };

        
        static Option<TResult?> Single<TSource, TResult, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate.Invoke(source[index]))
                            return Option.None;
                    }

                    return Option.Some(selector(first));
                }
            }
            return Option.None;
        }
    }
}
