using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => (TSource[])source.Clone();
    }
}

