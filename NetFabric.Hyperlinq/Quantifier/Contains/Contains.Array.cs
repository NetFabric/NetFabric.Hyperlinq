using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value)
            => ((ICollection<TSource>)source).Contains(value);

#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer)
            => comparer is null
                ? ((ICollection<TSource>)source).Contains(value)
                : Array.Contains((ReadOnlySpan<TSource>)source, value, comparer);

#else

        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer)
        {
            if (source.Length == 0)
                return false;

            if (comparer is null)
                return ((ICollection<TSource>)source).Contains(value);

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(TSource[] source, TSource value)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TSource[] source, TSource value, IEqualityComparer<TSource> comparer)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (comparer.Equals(source[index], value))
                        return true;
                }
                return false;
            }
        }

        static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
        {
            if (takeCount == 0)
                return false;

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value, skipCount, takeCount);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer, skipCount, takeCount);

            static bool DefaultContains(TSource[] source, TSource value, int skipCount, int takeCount)
            {
                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                            return true;
                    }
                }
                return false;
            }

            static bool ComparerContains(TSource[] source, TSource value, IEqualityComparer<TSource> comparer, int skipCount, int takeCount)
            {
                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (comparer.Equals(source[index], value))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (comparer.Equals(source[index], value))
                            return true;
                    }
                }
                return false;
            }
        }

#endif

        static bool Contains<TSource, TResult>(this TSource[] source, TResult value, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            if (takeCount == 0)
                return false;

            return default(TResult) is object
                ? ValueContains(source, value, selector, skipCount, takeCount)
                : ReferenceContains(source, value, selector, skipCount, takeCount);

            static bool ValueContains(TSource[] source, TResult value, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index]), value))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index]), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TSource[] source, TResult value, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (skipCount == 0 && takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index]), value))
                            return true;
                    }
                }
                else
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index]), value))
                            return true;
                    }
                }
                return false;
            }
        }


        static bool Contains<TSource, TResult>(this TSource[] source, TResult value, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
        {
            if (takeCount == 0)
                return false;

            return default(TResult) is object
                ? ValueContains(source, value, selector, skipCount, takeCount)
                : ReferenceContains(source, value, selector, skipCount, takeCount);

            static bool ValueContains(TSource[] source, TResult value, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            {
                if (skipCount == 0)
                {
                    if (takeCount == source.Length)
                    {
                        for (var index = 0; index < source.Length; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(source[index], index), value))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(source[index], index), value))
                                return true;
                        }
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index + skipCount], index), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TSource[] source, TResult value, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                if (skipCount == 0)
                {
                    if (takeCount == source.Length)
                    {
                        for (var index = 0; index < source.Length; index++)
                        {
                            if (defaultComparer.Equals(selector(source[index], index), value))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            if (defaultComparer.Equals(selector(source[index], index), value))
                                return true;
                        }
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index + skipCount], index), value))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}

