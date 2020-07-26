using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source)
            => source.Count != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            var array = source.Array;
            if (source.IsWhole())
            {
                foreach (var item in array)
                {
                    if (predicate(item))
                        return true;
                }
            }
            else
            {
                var end = source.Count + source.Offset;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                        return true;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            var array = source.Array;
            if (source.IsWhole())
            {
                var index = 0;
                foreach (var item in array)
                {
                    if (predicate(item, index))
                        return true;

                    index++;
                }
            }
            else
            {
                if (source.Offset == 0)
                {
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
                    {
                        if (predicate(array[index], index))
                            return true;
                    }
                }
                else
                {
                    var offset = source.Offset;
                    var end = source.Count;
                    for (var index = 0; index < end; index++)
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

