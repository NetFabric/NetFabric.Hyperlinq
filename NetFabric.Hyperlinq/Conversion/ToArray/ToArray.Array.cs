using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => (TSource[])source.Clone();

        static TSource[] ToArray<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            var array = new TSource[takeCount];
            for (var index = 0; index < takeCount; index++)
                array[index] = source[index + skipCount];
            return array;
        }
    }
}
