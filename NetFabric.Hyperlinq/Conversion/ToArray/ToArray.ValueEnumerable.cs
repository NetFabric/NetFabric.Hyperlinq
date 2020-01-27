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
    }
}