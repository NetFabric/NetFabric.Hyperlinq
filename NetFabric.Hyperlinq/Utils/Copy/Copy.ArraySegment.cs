using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(in ArraySegment<TSource> source, in ArraySegment<TSource> destination)
        {
            Debug.Assert(destination.Count - destination.Offset >= source.Count);

            Array.Copy(source.Array, source.Offset, destination.Array, destination.Offset, source.Count);
        }

        public static void Copy<TSource, TResult>(in ArraySegment<TSource> source, in ArraySegment<TResult> destination, NullableSelector<TSource, TResult> selector)
        {
            Debug.Assert(destination.Count >= source.Count);

            if (source.Count == 0)
                return;

            var sourceArray = source.Array;
            var destinationArray = destination.Array;
            var sourceCount = source.Count;

            if (destination.Offset == 0)
            {
                if (source.Offset == 0)
                {
                    if (sourceCount == sourceArray.Length)
                    {
                        for (var index = 0; index < sourceArray.Length; index++)
                            destinationArray[index] = selector(sourceArray[index])!;
                    }
                    else
                    {
                        for (var index = 0; index < sourceCount; index++)
                            destinationArray[index] = selector(sourceArray[index])!;
                    }
                }
                else
                {
                    var sourceOffset = source.Offset;
                    for (var index = 0; index < sourceCount; index++)
                        destinationArray[index] = selector(sourceArray[index + sourceOffset])!;
                }
            }
            else
            {
                var destinationOffset = destination.Offset;
                if (source.Offset == 0)
                {
                    if (sourceCount == sourceArray.Length)
                    {
                        for (var index = 0; index < sourceArray.Length; index++)
                            destinationArray[index + destinationOffset] = selector(sourceArray[index])!;
                    }
                    else
                    {
                        for (var index = 0; index < sourceCount; index++)
                            destinationArray[index + destinationOffset] = selector(sourceArray[index])!;
                    }
                }
                else
                {
                    var sourceOffset = source.Offset;
                    for (var index = 0; index < sourceCount; index++)
                        destinationArray[index + destinationOffset] = selector(sourceArray[index + sourceOffset])!;
                }
            }
        }

        public static void Copy<TSource, TResult>(in ArraySegment<TSource> source, in ArraySegment<TResult> destination, NullableSelectorAt<TSource, TResult> selector)
        {
            Debug.Assert(destination.Count >= source.Count);

            if (source.Count == 0)
                return;

            var sourceArray = source.Array;
            var destinationArray = destination.Array;
            var sourceCount = source.Count;

            if (destination.Offset == 0)
            {
                if (source.Offset == 0)
                {
                    if (sourceCount == sourceArray.Length)
                    {
                        for (var index = 0; index < sourceArray.Length; index++)
                            destinationArray[index] = selector(sourceArray[index], index)!;
                    }
                    else
                    {
                        for (var index = 0; index < sourceCount; index++)
                            destinationArray[index] = selector(sourceArray[index], index)!;
                    }
                }
                else
                {
                    var sourceOffset = source.Offset;
                    for (var index = 0; index < sourceCount; index++)
                        destinationArray[index] = selector(sourceArray[index + sourceOffset], index)!;
                }
            }
            else
            {
                var destinationOffset = destination.Offset;
                if (source.Offset == 0)
                {
                    if (sourceCount == sourceArray.Length)
                    {
                        for (var index = 0; index < sourceArray.Length; index++)
                            destinationArray[index + destinationOffset] = selector(sourceArray[index], index)!;
                    }
                    else
                    {
                        for (var index = 0; index < sourceCount; index++)
                            destinationArray[index + destinationOffset] = selector(sourceArray[index], index)!;
                    }
                }
                else
                {
                    var sourceOffset = source.Offset;
                    for (var index = 0; index < sourceCount; index++)
                        destinationArray[index + destinationOffset] = selector(sourceArray[index + sourceOffset], index)!;
                }
            }
        }
    }
}
