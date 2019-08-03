using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => source.Clone() as TSource[];

        static TSource[] ToArray<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            var array = new TSource[takeCount];
            System.Array.Copy(source, skipCount, array, 0, takeCount);
            return array;
        }
    }
}
