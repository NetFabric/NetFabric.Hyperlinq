using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static int Count<TSource>(this TSource[] source)
            => source.Length;
    }
}

