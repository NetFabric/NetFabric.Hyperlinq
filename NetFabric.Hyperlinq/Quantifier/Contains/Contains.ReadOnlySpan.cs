using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        public static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = null)
        {
            if (source.Length != 0) 
            {
                if (comparer is null)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(value, source[index]))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (comparer.Equals(value, source[index]))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource>? comparer, Predicate<TSource> predicate)
        {
            if (source.Length != 0) 
            {
                if (comparer is null)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && EqualityComparer<TSource>.Default.Equals(value, item))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && comparer.Equals(value, item))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource>? comparer, PredicateAt<TSource> predicate)
        {
            if (source.Length != 0) 
            {
                if (comparer is null)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item, index) && EqualityComparer<TSource>.Default.Equals(value, item))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item, index) && comparer.Equals(value, item))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static bool Contains<TSource, TResult>(this ReadOnlySpan<TSource> source, TResult value, IEqualityComparer<TResult>? comparer, Selector<TSource, TResult> selector)
        {
            if (source.Length != 0) 
            {
                if (comparer is null)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(value, selector(source[index])))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (comparer.Equals(value, selector(source[index])))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static bool Contains<TSource, TResult>(this ReadOnlySpan<TSource> source, TResult value, IEqualityComparer<TResult>? comparer, SelectorAt<TSource, TResult> selector)
        {
            if (source.Length != 0) 
            {
                if (comparer is null)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(value, selector(source[index], index)))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (comparer.Equals(value, selector(source[index], index)))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static bool Contains<TSource, TResult>(this ReadOnlySpan<TSource> source, TResult value, IEqualityComparer<TResult>? comparer, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            if (source.Length != 0) 
            {
                if (comparer is null)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var item = source[index];
                        if (predicate(item) && EqualityComparer<TResult>.Default.Equals(value, selector(item)))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Length; index++)
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

