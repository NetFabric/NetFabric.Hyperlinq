using NetFabric.Hyperlinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => (TSource[])source.Clone();

#if SPAN_SUPPORTED

#else

        static TSource[] ToArray<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            var array = new TSource[takeCount];
            if (takeCount != 0)
            {
                if (takeCount == source.Length && source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, skipCount);
                }
                else
                {
                    if (skipCount == 0)
                    {
                        if (takeCount == source.Length)
                        {
                            for (var index = 0; index < source.Length; index++)
                                array[index] = source[index];
                        }
                        else
                        {
                            for (var index = 0; index < takeCount; index++)
                                array[index] = source[index];
                        }
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


        static TSource[] ToArray<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange<TSource[]>(source, predicate, skipCount, takeCount);
            return builder.ToArray();
        }


        static TSource[] ToArray<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange<TSource[]>(source, predicate, skipCount, takeCount);
            return builder.ToArray();
        }


        static TResult[] ToArray<TSource, TResult>(this TSource[] source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var array = new TResult[takeCount];
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                        array[index] = selector(source[index]);
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index]);
                }
            } 
            else
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount]);
            }
            return array;
        }


        static TResult[] ToArray<TSource, TResult>(this TSource[] source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var array = new TResult[takeCount];
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                        array[index] = selector(source[index], index);
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index], index);
                }
            } 
            else
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount], index);
            }
            return array;
        }


        static TResult[] ToArray<TSource, TResult>(this TSource[] source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            builder.AddRange<TSource>(source, predicate, selector, skipCount, takeCount);
            return builder.ToArray();
        }
    }
}

namespace System.Collections.Generic
{
    partial struct LargeArrayBuilder<T>
    {
        public void AddRange(T[] items, Predicate<T> predicate, int skipCount, int takeCount)
        {
            Debug.Assert(items is object);

            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            if (skipCount == 0 && takeCount == items.Length)
            {
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
            }
            else
            {
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
            }
            
            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

        public void AddRange(T[] items, PredicateAt<T> predicate, int skipCount, int takeCount)
        {
            Debug.Assert(items is object);

            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            if (skipCount == 0)
            {
                if (takeCount == items.Length)
                {
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
                }
                else
                {
                    for (var itemIndex = 0; itemIndex < takeCount; itemIndex++)
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
                }
            }
            else
            {
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
            }

            
            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

        public void AddRange<U>(U[] items, Predicate<U> predicate, NullableSelector<U, T> selector, int skipCount, int takeCount)
        {
            Debug.Assert(items is object);

            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            if (skipCount == 0 && takeCount == items.Length)
            {
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
            }
            else
            {
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
            }
            
            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

#endif
    }
}

