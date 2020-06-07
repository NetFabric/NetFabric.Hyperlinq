using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {

#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this TSource[] source)
            => First<TSource>((ReadOnlySpan<TSource>)source.AsSpan());

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this TSource[] source)
            => First(source, 0, source.Length);


        static Option<TSource> First<TSource>(this TSource[] source, int skipCount, int takeCount)
            => takeCount switch
            {
                0 => Option.None,
                _ => Option.Some(source[skipCount]),
            };


        static Option<TSource> First<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        return Option.Some(item);
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        static Option<TSource> First<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item, index))
                            return Option.Some(item);
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        var item = source[index];
                        if (predicate(item, index))
                            return Option.Some(item);
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult>(this TSource[] source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            => takeCount switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[skipCount])),
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TSource, TResult>(this TSource[] source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            => takeCount switch
            {
                0 => Option.None,
                _ => Option.Some(selector(source[skipCount], 0)),
            };


        static Option<TResult> First<TSource, TResult>(this TSource[] source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                        return Option.Some(selector(source[index]));
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        return Option.Some(selector(source[index]));
                }
            }
            return Option.None;
        }

#endif
    }
}
