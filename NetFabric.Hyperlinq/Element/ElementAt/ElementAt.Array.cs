using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this TSource[] source, int index)
            => ElementAt((ReadOnlySpan<TSource>)source.AsSpan(), index);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this TSource[] source, int index)
            => ElementAt(source, index, 0, source.Length);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> ElementAt<TSource>(this TSource[] source, int index, int skipCount, int takeCount)
            => index < 0 || index >= takeCount
                ? Option.None
                : Option.Some(source[index + skipCount]);


        static Option<TSource> ElementAt<TSource>(this TSource[] source, int index, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            if (index >= 0)
            {
                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }


        static Option<TSource> ElementAt<TSource>(this TSource[] source, int index, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            if (index >= 0)
            {
                if (skipCount == 0)
                {
                    if (takeCount == source.Length)
                    {
                        for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                        {
                            var item = source[sourceIndex];
                            if (predicate(item, sourceIndex) && index-- == 0)
                                return Option.Some(item);
                        }
                    }
                    else
                    {
                        for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                        {
                            var item = source[sourceIndex];
                            if (predicate(item, sourceIndex) && index-- == 0)
                                return Option.Some(item);
                        }
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex < takeCount; sourceIndex++)
                    {
                        var item = source[sourceIndex + skipCount];
                        if (predicate(item, sourceIndex) && index-- == 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> ElementAt<TSource, TResult>(this TSource[] source, int index, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            => index < 0 || index >= takeCount
                ? Option.None
                : Option.Some(selector(source[index + skipCount]));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> ElementAt<TSource, TResult>(this TSource[] source, int index, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            => index < 0 || index >= takeCount
                ? Option.None
                : Option.Some(selector(source[index + skipCount], index));


        static Option<TResult> ElementAt<TSource, TResult>(this TSource[] source, int index, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            if (index >= 0)
            {
                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(selector(item));
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var sourceIndex = skipCount; sourceIndex < end; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate(item) && index-- == 0)
                            return Option.Some(selector(item));
                    }
                }
            }
            return Option.None;
        }

#endif
    }
}
