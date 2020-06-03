using NetFabric.Hyperlinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => ToArray<TList, TSource>(source, 0, source.Count);

        
        internal static TSource[] ToArray<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var array = new TSource[takeCount];
            if (takeCount != 0)
            {
                if (takeCount == source.Count && source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, skipCount);
                }
                else
                {
                    if (skipCount == 0)
                    {
                        for (var index = 0; index < takeCount; index++)
                            array[index] = source[index];
                    }
                    else
                    {
                        for (var index = 0; index < takeCount; index++)
                            array[index] = source[index + skipCount];
                    }
                }
            }
            return array;
        }


        internal static TSource[] ToArray<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange<TList>(source, predicate, skipCount, takeCount);
            return builder.ToArray();
        }


        internal static TSource[] ToArray<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange<TList>(source, predicate, skipCount, takeCount);
            return builder.ToArray();
        }


        internal static TResult[] ToArray<TList, TSource, TResult>(this TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var array = new TResult[takeCount];
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index]);
            } 
            else
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount]);
            }
            return array;
        }


        internal static TResult[] ToArray<TList, TSource, TResult>(this TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var array = new TResult[takeCount];
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index], index);
            } 
            else
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount], index);
            }
            return array;
        }


        internal static TResult[] ToArray<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            builder.AddRange<TList, TSource>(source, predicate, selector, skipCount, takeCount);
            return builder.ToArray();
        }
    }
}

namespace System.Collections.Generic
{
    internal partial struct LargeArrayBuilder<T>
    {
        public void AddRange<TList>(TList items, Predicate<T> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<T>
        {
            Debug.Assert(items is object);

            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            var end = skipCount + takeCount;
            for (var itemIndex = skipCount; itemIndex < end; itemIndex++)
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

        public void AddRange<TList>(TList items, PredicateAt<T> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<T>
        {
            Debug.Assert(items is object);

            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            for (var itemIndex = 0; itemIndex < takeCount; itemIndex++)
            {
                var item = items[itemIndex + skipCount];
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

        public void AddRange<TList, U>(TList items, Predicate<U> predicate, Selector<U, T> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<U>
        {
            Debug.Assert(items is object);

            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            var end = skipCount + takeCount;
            for (var itemIndex = skipCount; itemIndex < end; itemIndex++)
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

