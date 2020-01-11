using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action)
        {
            for (var index = 0; index < source.Length; index++)
                action(source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource, int> action)
        {
            for (var index = 0; index < source.Length; index++)
                action(source[index], index);
        }
    }
}

