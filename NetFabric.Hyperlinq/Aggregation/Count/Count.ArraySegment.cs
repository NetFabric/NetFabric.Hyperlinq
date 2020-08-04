using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this in ArraySegment<TSource> source)
            => source.Count;

        static unsafe int Count<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var counter = 0;
            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Count == array!.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var result = predicate(array![index]);
                        counter += *(int*)&result;
                    }
                }
                else
                {
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var result = predicate(array![index]);
                        counter += *(int*)&result;
                    }
                }
            }
            return counter;
        }

        static unsafe int Count<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            if (source.Array is null)
                Throw.ArgumentArraySegmentNullException(nameof(source));

            var counter = 0;
            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Count == array!.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var result = predicate(array![index], index);
                        counter += *(int*)&result;
                    }
                }
                else
                {
                    var end = source.Count - 1;
                    if (source.Offset == 0)
                    {
                        for (var index = 0; index <= end; index++)
                        {
                            var result = predicate(array![index], index);
                            counter += *(int*)&result;
                        }
                    }
                    else
                    {
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                        {
                            var result = predicate(array![index + offset], index);
                            counter += *(int*)&result;
                        }
                    }
                }
            }
            return counter;
        }
    }
}

