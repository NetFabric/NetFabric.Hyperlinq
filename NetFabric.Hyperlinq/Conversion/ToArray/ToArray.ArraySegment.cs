using NetFabric.Hyperlinq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source)
        {
            var result = new TSource[source.Count];
            Array.Copy(source.Array, source.Offset, result, 0, source.Count);
            return result;
        }

        static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange(source, predicate);
            return builder.ToArray();
        }


        static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange(source, predicate);
            return builder.ToArray();
        }


        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
        {
            var array = source.Array;
            var result = new TResult[source.Count];
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < result.Length; index++)
                        result[index] = selector(array[index]);
                }
                else
                {
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
                        result[index] = selector(array[index]);
                }
            } 
            else
            {
                var offset = source.Offset;
                var end = source.Count;
                for (var index = 0; index < end; index++)
                    result[index] = selector(array[index + offset]);
            }
            return result;
        }


        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
            var array = source.Array;
            var result = new TResult[source.Count];
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                        result[index] = selector(array[index], index);
                }
                else
                {
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
                        result[index] = selector(array[index], index);
                }
            } 
            else
            {
                var offset = source.Offset;
                var end = source.Count;
                for (var index = 0; index < end; index++)
                    result[index] = selector(array[index + offset], index);
            }
            return result;
        }


        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            builder.AddRange<TSource>(source, predicate, selector);
            return builder.ToArray();
        }
    }
}

namespace System.Collections.Generic
{
    partial struct LargeArrayBuilder<T>
    {
        public void AddRange(in ArraySegment<T> source, Predicate<T> predicate)
        {
            var array = source.Array;
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                {
                    var item = array[sourceIndex];
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
                var end = source.Offset + source.Count;
                for (var sourceIndex = source.Offset; sourceIndex < end; sourceIndex++)
                {
                    var item = array[sourceIndex];
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

        public void AddRange(in ArraySegment<T> source, PredicateAt<T> predicate)
        {
            var array = source.Array;
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate(item, sourceIndex))
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
                    for (var sourceIndex = 0; sourceIndex < source.Count; sourceIndex++)
                    {
                        var item = array[sourceIndex];
                        if (predicate(item, sourceIndex))
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
                var offset = source.Offset;
                var count = source.Count;
                for (var sourceIndex = 0; sourceIndex < count; sourceIndex++)
                {
                    var item = array[sourceIndex + offset];
                    if (predicate(item, sourceIndex))
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

        public void AddRange<U>(in ArraySegment<U> source, Predicate<U> predicate, NullableSelector<U, T> selector)
        {
            var array = source.Array;
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                {
                    var item = array[sourceIndex];
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
                var end = source.Offset + source.Count;
                for (var sourceIndex = source.Offset; sourceIndex < end; sourceIndex++)
                {
                    var item = array[sourceIndex];
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
    }
}

