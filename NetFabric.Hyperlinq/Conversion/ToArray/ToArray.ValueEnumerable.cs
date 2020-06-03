using NetFabric.Hyperlinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source)
            {
                case ICollection<TSource> collection:
                    var count = collection.Count;
                    if (count == 0)
                        return System.Array.Empty<TSource>();

                    var buffer = new TSource[count];
                    collection.CopyTo(buffer, 0);
                    return buffer;

                default:
                    var builder = new LargeArrayBuilder<TSource>(initialize: true);
                    builder.AddRange<TEnumerable, TEnumerator>(source);
                    return builder.ToArray();
            }
        }

        
        static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange<TEnumerable, TEnumerator>(source, predicate);
            return builder.ToArray();
        }

        
        static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            builder.AddRange<TEnumerable, TEnumerator>(source, predicate);
            return builder.ToArray();
        }

        
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            builder.AddRange<TEnumerable, TEnumerator, TSource>(source, selector);
            return builder.ToArray();
        }

        
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            builder.AddRange<TEnumerable, TEnumerator, TSource>(source, selector);
            return builder.ToArray();
        }

        
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            builder.AddRange<TEnumerable, TEnumerator, TSource>(source, predicate, selector);
            return builder.ToArray();
        }
    }
}

namespace System.Collections.Generic
{
    internal partial struct LargeArrayBuilder<T>
    {
        public void AddRange<TEnumerable, TEnumerator>(TEnumerable items)
            where TEnumerable : notnull, IValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IEnumerator<T>
        {
            Debug.Assert(items is object);

            using var enumerator = items.GetEnumerator();
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if ((uint)index >= (uint)destination.Length)
                    AddWithBufferAllocation(item, ref destination, ref index);
                else
                    destination[index] = item;

                index++;
            }

            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

        public void AddRange<TEnumerable, TEnumerator>(TEnumerable items, Predicate<T> predicate)
            where TEnumerable : notnull, IValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IEnumerator<T>
        {
            Debug.Assert(items is object);

            using var enumerator = items.GetEnumerator();
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
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

        public void AddRange<TEnumerable, TEnumerator>(TEnumerable items, PredicateAt<T> predicate)
            where TEnumerable : notnull, IValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IEnumerator<T>
        {
            Debug.Assert(items is object);

            using var enumerator = items.GetEnumerator();
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            for (var itemIndex = 0; enumerator.MoveNext(); itemIndex++)
            {
                var item = enumerator.Current;
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

        public void AddRange<TEnumerable, TEnumerator, U>(TEnumerable items, Selector<U, T> selector)
            where TEnumerable : notnull, IValueEnumerable<U, TEnumerator>
            where TEnumerator : struct, IEnumerator<U>
        {
            Debug.Assert(items is object);

            using var enumerator = items.GetEnumerator();
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if ((uint)index >= (uint)destination.Length)
                    AddWithBufferAllocation(selector(item), ref destination, ref index);
                else
                    destination[index] = selector(item);

                index++;
            }

            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

        public void AddRange<TEnumerable, TEnumerator, U>(TEnumerable items, SelectorAt<U, T> selector)
            where TEnumerable : notnull, IValueEnumerable<U, TEnumerator>
            where TEnumerator : struct, IEnumerator<U>
        {
            Debug.Assert(items is object);

            using var enumerator = items.GetEnumerator();
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if ((uint)index >= (uint)destination.Length)
                    AddWithBufferAllocation(selector(item, index), ref destination, ref index);
                else
                    destination[index] = selector(item, index);

                index++;
            }

            // Final update to _count and _index.
            _count += index - _index;
            _index = index;
        }

        public void AddRange<TEnumerable, TEnumerator, U>(TEnumerable items, Predicate<U> predicate, Selector<U, T> selector)
            where TEnumerable : notnull, IValueEnumerable<U, TEnumerator>
            where TEnumerator : struct, IEnumerator<U>
        {
            Debug.Assert(items is object);

            using var enumerator = items.GetEnumerator();
            var destination = _current;
            var index = _index;

            // Continuously read in items from the enumerator, updating _count
            // and _index when we run out of space.

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
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