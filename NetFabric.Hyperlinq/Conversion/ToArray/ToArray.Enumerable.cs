using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        [Pure]
        static T[] ToArray<T>(IEnumerable<T> source)
        {
            var (array, length) = ToArrayWithLength(source);
            System.Array.Resize(ref array, length);
            return array;

            static (T[]?, int) ToArrayWithLength(IEnumerable<T> source)
            {
                if (source is ICollection<T> collection)
                {
                    var count = collection.Count;
                    if (count == 0)
                        return default;

                    var buffer = new T[count];
                    collection.CopyTo(buffer, 0);
                    return (buffer, count);
                }

                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var array = Utils.ToArrayAllocate<T>();
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