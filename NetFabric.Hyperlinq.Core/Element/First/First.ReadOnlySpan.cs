using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> First<TSource>(this ReadOnlySpan<TSource> source) 
            => source switch
            {
                { Length: 0 } => Option.None,
                _ => Option.Some(source[0])
            };


        static Option<TSource> First<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    return Option.Some(item);
            }

            return Option.None;
        }



        static Option<TSource> FirstAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    return Option.Some(item);
            }
            return Option.None;
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Length: 0 } => Option.None,
                _ => Option.Some(selector.Invoke(source[0])),
            };



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> FirstAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source switch
            {
                { Length: 0 } => Option.None,
                _ => Option.Some(selector.Invoke(source[0], 0)),
            };



        static Option<TResult> First<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    return Option.Some(selector.Invoke(item));
            }

            return Option.None;
        }
    }
}
