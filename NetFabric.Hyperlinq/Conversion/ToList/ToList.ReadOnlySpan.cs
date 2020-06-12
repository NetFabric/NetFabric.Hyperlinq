using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        public static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source)
        {
            var list = new List<TSource>(source.Length);
            for (var index = 0; index < source.Length; index++)
            {
                list.Add(source[index]);
            }
            return list;
        }

        
        static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            var list = new List<TSource>(source.Length);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate(item))
                    list.Add(item);
            }
            return list;
        }

        
        static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            var list = new List<TSource>(source.Length);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate(item, index))
                    list.Add(item);
            }
            return list;
        }

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
        {
            var list = new List<TResult>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(selector(source[index]));
            return list;
        }

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
        {
            var list = new List<TResult>(source.Length);
            for (var index = 0; index < source.Length; index++)
                list.Add(selector(source[index], index));
            return list;
        }

        
        static List<TResult> ToList<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            var list = new List<TResult>(source.Length);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate(item))
                    list.Add(selector(item));
            }
            return list;
        }
    }
}
