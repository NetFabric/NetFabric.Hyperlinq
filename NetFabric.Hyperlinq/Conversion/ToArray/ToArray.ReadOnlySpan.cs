using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using NetFabric.Hyperlinq;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        static TSource[] ToArray<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange(source, predicate);
            return builder.ToArray();
        }

        
        static TSource[] ToArray<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange(source, predicate);
            return builder.ToArray();
        }

        
        static TResult[] ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
        {
            var array = new TResult[source.Length];
            for (var index = 0; index < source.Length; index++)
                array[index] = selector(source[index]);
            return array;
        }

        
        static TResult[] ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
        {
            var array = new TResult[source.Length];
            for (var index = 0; index < source.Length; index++)
                array[index] = selector(source[index], index);
            return array;
        }

        
        static TResult[] ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            builder.AddRange<TSource>(source, predicate, selector);
            return builder.ToArray();
        }
    }
}

namespace System.Collections.Generic
{
    internal partial struct LargeArrayBuilder<T>
    {
        public void AddRange(ReadOnlySpan<T> items, Predicate<T> predicate)
        {
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            for (var itemIndex = 0; itemIndex < items.Length; itemIndex++)
            {
                var item = items[itemIndex];
                if (predicate(item))
                {
                    if ((uint)index >= (uint)destination.Length)
                        AddWithBufferAllocation(item, ref destination, ref index);
                    else
                        destination[index] = item;

                    index++;
                }
            }
            
            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

        public void AddRange(ReadOnlySpan<T> items, PredicateAt<T> predicate)
        {
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            for (var itemIndex = 0; itemIndex < items.Length; itemIndex++)
            {
                var item = items[itemIndex];
                if (predicate(item, itemIndex))
                {
                    if ((uint)index >= (uint)destination.Length)
                        AddWithBufferAllocation(item, ref destination, ref index);
                    else
                        destination[index] = item;

                    index++;
                }
            }
            
            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

        public void AddRange<U>(ReadOnlySpan<U> items, Predicate<U> predicate, Selector<U, T> selector)
        {
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            for (var itemIndex = 0; itemIndex < items.Length; itemIndex++)
            {
                var item = items[itemIndex];
                if (predicate(item))
                {
                    if ((uint)index >= (uint)destination.Length)
                        AddWithBufferAllocation(selector(item), ref destination, ref index);
                    else
                        destination[index] = selector(item);

                    index++;
                }
            }
            
            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }
    }
}

