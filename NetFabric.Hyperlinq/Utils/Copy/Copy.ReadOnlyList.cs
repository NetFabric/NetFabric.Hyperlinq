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

            if (count == 0)
                return;

            if (sourceOffset == 0)
            {
                if (count == source.Count && source is ICollection<TSource> collection)
                {
                    collection.CopyTo(destination, destinationOffset);
                }
                else
                {
                    if (destinationOffset == 0)
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
                if (destinationOffset == 0)
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

            if (count == 0)
                return;

            if (sourceOffset == 0)
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

        public static void Copy<TList, TSource, TResult>(TList source, int sourceOffset, TResult[] destination, int destinationOffset, int count, NullableSelector<TSource, TResult> selector)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length - destinationOffset >= count);

            if (count == 0)
                return;

            if (destinationOffset == 0)
            {
                if (sourceOffset == 0)
                {
                    for (var index = 0; index < count; index++)
                        destination[index] = selector(source[index])!;
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        destination[index] = selector(source[index + sourceOffset])!;
                }
            }
            else
            {
                if (sourceOffset == 0)
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector(source[index])!;
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector(source[index + sourceOffset])!;
                }
            }
        }

        public static void Copy<TList, TSource, TResult>(TList source, int sourceOffset, Span<TResult> destination, int count, NullableSelector<TSource, TResult> selector)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length >= count);

            if (count == 0)
                return;

            if (sourceOffset == 0)
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector(source[index])!;
            }
            else
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector(source[index + sourceOffset])!;
            }
        }

        public static void Copy<TList, TSource, TResult>(TList source, int sourceOffset, TResult[] destination, int destinationOffset, int count, NullableSelectorAt<TSource, TResult> selector)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length - destinationOffset >= count);

            if (count == 0)
                return;

            if (destinationOffset == 0)
            {
                if (sourceOffset == 0)
                {
                    for (var index = 0; index < count; index++)
                        destination[index] = selector(source[index], index)!;
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        destination[index] = selector(source[index + sourceOffset], index)!;
                }
            }
            else
            {
                if (sourceOffset == 0)
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector(source[index], index)!;
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        destination[index + destinationOffset] = selector(source[index + sourceOffset], index)!;
                }
            }
        }

        public static void Copy<TList, TSource, TResult>(TList source, int sourceOffset, Span<TResult> destination, int count, NullableSelectorAt<TSource, TResult> selector)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(source.Count >= sourceOffset);
            Debug.Assert(destination.Length >= count);

            if (count == 0)
                return;

            if (sourceOffset == 0)
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector(source[index], index)!;
            }
            else
            {
                for (var index = 0; index < count; index++)
                    destination[index] = selector(source[index + sourceOffset], index)!;
            }
        }

    }
}
