using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        public static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer = null)
            where TList : notnull, IReadOnlyList<TSource>
            => Contains<TList, TSource>(source, value, comparer, 0, source.Count);

        [Pure]
        static bool Contains<TList, TSource>(this TList source, TSource value, IEqualityComparer<TSource>? comparer, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (takeCount != 0)
            {
                var end = skipCount + takeCount;
                if (comparer is null)
                {
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                            return true;
                    }
                }
                else
                {
                    for (var index = skipCount; index < end; index++)
                    {
                        if (comparer.Equals(source[index], value))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}

