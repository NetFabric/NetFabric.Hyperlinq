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
        static TSource[] ToArray<TSource>(IReadOnlyList<TSource> source)
            => ToArray<TSource>(source, 0, source.Count);

        [Pure]
        internal static TSource[] ToArray<TSource>(IReadOnlyList<TSource> source, int skipCount, int takeCount)
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
    }
}
