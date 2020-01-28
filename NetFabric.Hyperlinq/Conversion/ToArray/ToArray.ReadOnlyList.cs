using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var array = new TSource[source.Count];
            if (source is ICollection<TSource> collection)
            {
                collection.CopyTo(array, 0);
            }
            else
            {
                for (var index = 0; index < source.Count; index++)
                    array[index] = source[index];
            }
            return array;
        }

        [Pure]
        static TSource[] ToArray<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var array = new TSource[takeCount];
            if (takeCount != 0)
            {
                if (skipCount == 0 && takeCount == source.Count && source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, 0);
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = source[index + skipCount];
                }
            }
            return array;
        }


        [Pure]
        static TSource[] ToArray<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var (array, length) = (skipCount == 0 && takeCount == source.Count)
                ? ToArrayWithLength(source, predicate)
                : IntervalToArrayWithLength(source, predicate, skipCount, takeCount);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[]?, int) ToArrayWithLength(TList source, Predicate<TSource> predicate)
            {
                TSource[]? array = null;
                var count = 0;
                for (var index = 0; index < source.Count; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                    {
                        if (count == 0)
                            array = Utils.ToArrayAllocate<TSource>();
                        else if (count == array!.Length)
                            Utils.ToArrayResize(ref array, count);

                        array[count] = item;
                        count++;
                    }
                }

                return (array, count);
            }

            static (TSource[]?, int) IntervalToArrayWithLength(TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                TSource[]? array = null;
                var count = 0;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                    {
                        if (count == 0)
                            array = Utils.ToArrayAllocate<TSource>();
                        else if (count == array!.Length)
                            Utils.ToArrayResize(ref array, count);

                        array[count] = item;
                        count++;
                    }
                }

                return (array, count);
            }
        }
    }
}
