using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (predicate(array[index]))
                            return true;
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (predicate(array[index]))
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool Any<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Offset == 0)
                {
                    if (source.Count == array.Length)
                    {
                        for (var index = 0; index < array.Length; index++)
                        {
                            if (predicate(array[index], index))
                                return true;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < source.Count; index++)
                        {
                            if (predicate(array[index], index))
                                return true;
                        }
                    }
                }
                else
                {
                    var offset = source.Offset;
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (predicate(array[index + offset], index))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}

