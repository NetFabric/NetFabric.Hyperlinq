using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryValueEnumerable<TSource> AsValueEnumerable<TSource>(this Memory<TSource> source)
            => ((ReadOnlyMemory<TSource>)source).AsValueEnumerable();
    }
}