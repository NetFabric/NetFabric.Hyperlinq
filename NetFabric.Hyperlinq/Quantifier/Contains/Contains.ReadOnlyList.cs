using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        
        public static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer = null)
            where TList : notnull, IReadOnlyList<TSource>
            => ReadOnlyList.Contains<TList, TSource>(source, value, comparer, 0, source.Count);

        
        static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount != 0) 
            {
                if (comparer is null)
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(value, source[index]))
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

        
        static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount != 0) 
            {
                if (comparer is null)
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && EqualityComparer<TSource>.Default.Equals(value, item))
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

        
        static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount != 0) 
            {
                if (skipCount == 0)
                {
                    if (comparer is null)
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            var item = source[index];
                            if (predicate(item, index) && EqualityComparer<TSource>.Default.Equals(value, item))
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
                    if (comparer is null)
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            var item = source[index + skipCount];
                            if (predicate(item, index) && EqualityComparer<TSource>.Default.Equals(value, item))
                                return true;
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
            }
            return false;
        }

        
        static bool Contains<TList, TSource, TResult>(this TList source, TResult value, IEqualityComparer<TResult>? comparer, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount != 0) 
            {
                if (comparer is null)
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(value, selector(source[index])))
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

        
        static bool Contains<TList, TSource, TResult>(this TList source, TResult value, IEqualityComparer<TResult>? comparer, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount != 0) 
            {
                if (skipCount == 0)
                {
                    if (comparer is null)
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(value, selector(source[index], index)))
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

                    if (comparer is null)
                    {
                        for (var index = 0; index < takeCount; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(value, selector(source[index + skipCount], index)))
                                return true;
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
            }
            return false;
        }

        
        static bool Contains<TList, TSource, TResult>(this TList source, TResult value, IEqualityComparer<TResult>? comparer, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount != 0) 
            {
                if (comparer is null)
                {
                    var end = skipCount + takeCount;
                    for (var index = skipCount; index < end; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && EqualityComparer<TResult>.Default.Equals(value, selector(item)))
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
    }
}

