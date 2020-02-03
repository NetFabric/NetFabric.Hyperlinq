using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        static TSource[] ToArray<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            var (array, length) = ToArrayWithLength(source, predicate);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[]?, int) ToArrayWithLength(ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
            {
                TSource[]? array = null;
                var count = 0;
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                    {
                        if (count == 0)
                            array = Utils.ToArrayAllocate<TSource>();
                        else if (count == array!.Length)
                            Utils.ToArrayResize(ref array, count);

                        array[count] = item;
                        count++;
                    }
                }

                return (array, count);
            }
        }

        [Pure]
        static TSource[] ToArray<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            var (array, length) = ToArrayWithLength(source, predicate);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[]?, int) ToArrayWithLength(ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
            {
                TSource[]? array = null;
                var count = 0;
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                    {
                        if (count == 0)
                            array = Utils.ToArrayAllocate<TSource>();
                        else if (count == array!.Length)
                            Utils.ToArrayResize(ref array, count);

                        array[count] = item;
                        count++;
                    }
                }

                return (array, count);
            }
        }
    }
}
