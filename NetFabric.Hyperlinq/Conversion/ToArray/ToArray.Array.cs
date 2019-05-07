using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => (TSource[])source.Clone();
    }
}
