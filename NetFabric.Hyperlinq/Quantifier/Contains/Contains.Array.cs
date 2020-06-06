using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer = null)
            => source.Contains(value, comparer);

#if SPAN_SUPPORTED


#else

        static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
        {
            if (takeCount != 0)
            {
                comparer ??= EqualityComparer<TSource>.Default;

                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (comparer.Equals(value, source[index]))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (comparer.Equals(value, source[index]))
                            return true;
                    }
                }
            }
            return false;
        }


        static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            if (takeCount != 0)
            {
                comparer ??= EqualityComparer<TSource>.Default;

                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && comparer.Equals(value, item))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && comparer.Equals(value, item))
                            return true;
                    }
                }
            }
            return false;
        }


        static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            if (takeCount != 0)
            {
                comparer ??= EqualityComparer<TSource>.Default;

                if (skipCount == 0)
                {
                    if (takeCount == source.Length)
                    {
                        for (var index = 0; index < source.Length; index++)
                        {
                            var item = source[index];
                            if (predicate(item, index) && comparer.Equals(value, item))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            var item = source[index];
                            if (predicate(item, index) && comparer.Equals(value, item))
                                return true;
                        }
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        var item = source[index + skipCount];
                        if (predicate(item, index) && comparer.Equals(value, item))
                            return true;
                    }
                }
            }
            return false;
        }


        static bool Contains<TSource, TResult>(this TSource[] source, TResult value, IEqualityComparer<TResult>? comparer, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            if (takeCount != 0)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (comparer.Equals(value, selector(source[index])))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (comparer.Equals(value, selector(source[index])))
                            return true;
                    }
                }
            }
            return false;
        }


        static bool Contains<TSource, TResult>(this TSource[] source, TResult value, IEqualityComparer<TResult>? comparer, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
        {
            if (takeCount != 0)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                if (skipCount == 0)
                {
                    if (takeCount == source.Length)
                    {
                        for (var index = 0; index < source.Length; index++)
                        {
                            if (comparer.Equals(value, selector(source[index], index)))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            if (comparer.Equals(value, selector(source[index], index)))
                                return true;
                        }
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (comparer.Equals(value, selector(source[index + skipCount], index)))
                            return true;
                    }
                }
            }
            return false;
        }


        static bool Contains<TSource, TResult>(this TSource[] source, TResult value, IEqualityComparer<TResult>? comparer, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            if (takeCount != 0)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && comparer.Equals(value, selector(item)))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && comparer.Equals(value, selector(item)))
                            return true;
                    }
                }
            }
            return false;
        }

#endif
    }
}

