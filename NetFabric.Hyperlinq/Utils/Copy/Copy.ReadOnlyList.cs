using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    static partial class ReadOnlyListExtensions
    {
        public static void Copy<TList, TSource>(TList source, int sourceOffset, TSource[] destination, int destinationOffset, int count)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length - destinationOffset >= count);

            if (count is 0)
                return;

            if (sourceOffset is 0)
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (count == source.Count && source is ICollection<TSource> collection)
                {
                    collection.CopyTo(destination, destinationOffset);
                }
                else
                {
                    if (destinationOffset is 0)
                    {
                        for (var index = 0; index < count; index++)
                            destination[index] = source[index];
                    }
                    else
                    {
                        for (var index = 0; index < count; index++)
                            destination[index + destinationOffset] = source[index];
                    }
                }
            }
            else
            {
                if (destinationOffset is 0)
                {
                    for (var index = 0; index < count; index++)
                        destination[index] = source[index + sourceOffset];
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = source[index + sourceOffset];
                }
            }
        }

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

        public static void Copy<TList, TSource, TResult, TSelector>(TList source, int sourceOffset, TResult[] destination, int destinationOffset, int count, TSelector selector = default)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length - destinationOffset >= count);

            if (count is 0)
                return;

            if (destinationOffset is 0)
            {
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
            else
            {
                if (sourceOffset is 0)
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector.Invoke(source[index]);
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector.Invoke(source[index + sourceOffset]);
                }
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

        public static void CopyAt<TList, TSource, TResult, TSelector>(TList source, int sourceOffset, TResult[] destination, int destinationOffset, int count, TSelector selector = default)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length - destinationOffset >= count);

            if (count is 0)
                return;

            if (destinationOffset is 0)
            {
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
            else
            {
                if (sourceOffset is 0)
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector.Invoke(source[index], index);
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector.Invoke(source[index + sourceOffset], index);
                }
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
