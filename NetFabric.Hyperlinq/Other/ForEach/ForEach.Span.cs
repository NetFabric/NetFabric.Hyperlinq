using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this Span<TSource> source, Action<TSource> action)
            => ForEach((ReadOnlySpan<TSource>)source, action);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this Span<TSource> source, ActionAt<TSource> action)
            => ForEach((ReadOnlySpan<TSource>)source, action);
    }
}

