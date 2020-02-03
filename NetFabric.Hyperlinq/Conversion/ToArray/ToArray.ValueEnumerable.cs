using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (array, length) = ToArrayWithLength(source);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[]?, int) ToArrayWithLength(TEnumerable source)
            {
                if (source is ICollection<TSource> collection)
                {
                    var count = collection.Count;
                    if (count == 0)
                        return default;

                    var buffer = new TSource[count];
                    collection.CopyTo(buffer, 0);
                    return (buffer, count);
                }

                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var array = Utils.ToArrayAllocate<TSource>();
                    array[0] = enumerator.Current;
                    var count = 1;

                    while (enumerator.MoveNext())
                    {
                        if (count == array.Length)
                            Utils.ToArrayResize(ref array, count);

                        array[count] = enumerator.Current;
                        count++;
                    }

                    return (array, count);
                }

                return default; // it's empty
            }
        }

        [Pure]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (array, length) = ToArrayWithLength(source, predicate);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[]?, int) ToArrayWithLength(TEnumerable source, Predicate<TSource> predicate)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                    {
                        var array = Utils.ToArrayAllocate<TSource>();
                        array[0] = enumerator.Current;
                        var count = 1;

                        while (enumerator.MoveNext())
                        {
                            var item = enumerator.Current;
                            if (predicate(item))
                            {
                                if (count == array.Length)
                                    Utils.ToArrayResize(ref array, count);

                                array[count] = item;
                                count++;
                            }
                        }

                        return (array, count);
                    }
                }

                return default; // it's empty
            }
        }

        [Pure]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var (array, length) = ToArrayWithLength(source, predicate);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[]?, int) ToArrayWithLength(TEnumerable source, PredicateAt<TSource> predicate)
            {
                using var enumerator = source.GetEnumerator();
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current, index))
                    {
                        var array = Utils.ToArrayAllocate<TSource>();
                        array[0] = enumerator.Current;
                        var count = 1;

                        // found first, keep going until end
                        for (index++; enumerator.MoveNext(); index++)
                        {
                            var item = enumerator.Current;
                            if (predicate(item, index))
                            {
                                if (count == array.Length)
                                    Utils.ToArrayResize(ref array, count);

                                array[count] = item;
                                count++;
                            }
                        }

                        return (array, count);
                    }
                }

                return default; // it's empty
            }
        }
    }
}