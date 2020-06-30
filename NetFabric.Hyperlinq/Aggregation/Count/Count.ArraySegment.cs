using System;
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
            var array = source.Array;
            var count = 0;
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var result = predicate(array[index]);
                        count += *(int*)&result;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        var result = predicate(array[index]);
                        count += *(int*)&result;
                    }
                }
            }
            else
            {
                var offset = source.Offset;
                for (var index = 0; index < source.Count; index++)
                {
                    var result = predicate(array[index + offset]);
                    count += *(int*)&result;
                }
            }
            return count;
        }

        static unsafe int Count<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            var count = 0;
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var result = predicate(array[index], index);
                        count += *(int*)&result;
                    }
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        var result = predicate(array[index], index);
                        count += *(int*)&result;
                    }
                }
            }
            else
            {
                var offset = source.Offset;
                for (var index = 0; index < source.Count; index++)
                {
                    var result = predicate(array[index + offset], index);
                    count += *(int*)&result;
                }
            }
            return count;
        }
    }
}

