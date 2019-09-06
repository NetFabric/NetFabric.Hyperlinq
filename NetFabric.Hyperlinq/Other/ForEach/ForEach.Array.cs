using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this TSource[] source, Action<TSource> action)
        {
            if (action is null) ThrowHelper.ThrowArgumentNullException(nameof(action));

            ForEach<TSource>(source, action, 0, source.Length);
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource> action, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TSource>(this TSource[] source, Action<TSource, int> action)
        {
            if (action is null) ThrowHelper.ThrowArgumentNullException(nameof(action));

            ForEach<TSource>(source, action, 0, source.Length);
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource, int> action, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index], index);
        }
    }
}

