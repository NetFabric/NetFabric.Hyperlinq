using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanValueEnumerable<TSource> AsValueEnumerable<TSource>(this Span<TSource> source)
            => ((ReadOnlySpan<TSource>)source).AsValueEnumerable();
    }
}