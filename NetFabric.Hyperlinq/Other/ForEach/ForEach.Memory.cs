using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this Memory<TSource> source, Action<TSource> action)
            => ForEach(source.Span, action);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this Memory<TSource> source, Action<TSource, int> action)
            => ForEach(source.Span, action);
    }
}

