using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this in ArraySegment<TSource> source)
            => source.Count;

        static int Count<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var counter = 0;
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                        counter += predicate(item).AsByte();
                }
                else
                {
                    var array = source.Array;
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                        counter += predicate(array![index]).AsByte();
                }
            }
            return counter;
        }

        static int Count<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var counter = 0;
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        counter += predicate(item, index).AsByte();
                        index++;
                    }
                }
                else
                {
                    var array = source.Array;
                    var end = source.Count - 1;
                    if (source.Offset == 0)
                    {
                        for (var index = 0; index <= end; index++)
                            counter += predicate(array![index], index).AsByte();
                    }
                    else
                    {
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                            counter += predicate(array![index + offset], index).AsByte();
                    }
                }
            }
            return counter;
        }
    }
}

