using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this TSource[] source)
            => Single((ReadOnlySpan<TSource>)source.AsSpan());

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this TSource[] source)
            => Single<TSource>(source, 0, source.Length);


        static Option<TSource> Single<TSource>(this TSource[] source, int skipCount, int takeCount)
            => takeCount switch
            {
                0 => Option.None,
                1 => Option.Some(source[skipCount]),
                _ => Option.None,
            };


        static Option<TSource> Single<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
            => GetSingle(source, predicate, skipCount, takeCount);


        static Option<TSource> Single<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            => GetSingle(source, predicate, skipCount, takeCount);


        static Option<TResult> Single<TSource, TResult>(this TSource[] source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            => takeCount switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[skipCount])),
                _ => Option.None,
            };


        static Option<TResult> Single<TSource, TResult>(this TSource[] source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            => takeCount switch
            {
                0 => Option.None,
                1 => Option.Some(selector(source[skipCount], 0)),
                _ => Option.None,
            };


        static Option<TResult> Single<TSource, TResult>(this TSource[] source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            => GetSingle(source, predicate, skipCount, takeCount).Select(selector);

        ////////////////////////////////
        // GetSingle 


        static Option<TSource> GetSingle<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                    {
                        var value = source[index];

                        for (index++; index < source.Length; index++)
                        {
                            if (predicate(source[index]))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                    {
                        var value = source[index];

                        for (index++; index < end; index++)
                        {
                            if (predicate(source[index]))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }
            return Option.None;
        }


        static Option<TSource> GetSingle<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (predicate(source[index], index))
                        {
                            var value = source[index];

                            for (index++; index < source.Length; index++)
                            {
                                if (predicate(source[index], index))
                                    return Option.None;
                            }

                            return Option.Some(value);
                        }
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (predicate(source[index], index))
                        {
                            var value = source[index];

                            for (index++; index < takeCount; index++)
                            {
                                if (predicate(source[index], index))
                                    return Option.None;
                            }

                            return Option.Some(value);
                        }
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index + skipCount], index))
                    {
                        var value = source[index + skipCount];

                        for (index++; index < takeCount; index++)
                        {
                            if (predicate(source[index + skipCount], index))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }
            }

            return Option.None;
        }

#endif
    }
}
