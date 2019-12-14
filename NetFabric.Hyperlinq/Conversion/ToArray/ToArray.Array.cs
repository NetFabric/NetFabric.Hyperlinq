using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => (TSource[])source.Clone();

        [Pure]
        static TSource[] ToArray<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            var array = new TSource[takeCount];
            if (takeCount != 0)
                System.Array.Copy(source, skipCount, array, 0, takeCount);
            return array;
        }
    }
}
