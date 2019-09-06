using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action)
            => ForEach<TSource>(source, action, 0, source.Length);

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource, int> action)
            => ForEach<TSource>(source, action, 0, source.Length);

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource, int> action, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index], index);
        }
    }
}

