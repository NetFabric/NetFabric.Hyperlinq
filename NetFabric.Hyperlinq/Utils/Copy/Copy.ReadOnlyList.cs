using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    static partial class ReadOnlyListExtensions
    {
        public static void Copy<TList, TSource>(TList source, int sourceOffset, Span<TSource> destination, int count)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length >= count);

            if (count is 0)
                return;

            if (sourceOffset is 0)
            {
                for (var index = 0; index < count; index++)
                    destination[index] = source[index];
            }
            else
            {
                for (var index = 0; index < count; index++)
                    destination[index] = source[index + sourceOffset];
            }
        }

        public static void Copy<TList, TSource, TResult, TSelector>(TList source, int sourceOffset, Span<TResult> destination, int count, TSelector selector = default)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length >= count);

            if (count is 0)
                return;

            if (sourceOffset is 0)
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector.Invoke(source[index]);
            }
            else
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector.Invoke(source[index + sourceOffset]);
            }
        }

        public static void CopyAt<TList, TSource, TResult, TSelector>(TList source, int sourceOffset, Span<TResult> destination, int count, TSelector selector = default)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length >= count);

            if (count is 0)
                return;

            if (sourceOffset is 0)
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector.Invoke(source[index], index);
            }
            else
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector.Invoke(source[index + sourceOffset], index);
            }
        }

    }
}
