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
        static bool Any<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item))
                            return true;
                    }
                }
                else
                {
                    var array = source.Array;
                    var end = source.Count + source.Offset - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        if (predicate.Invoke(array![index]))
                            return true;
                    }
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool AnyAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item, index))
                            return true;

                        index++;
                    }
                }
                else
                {
                    var end = source.Count - 1;
                    if (source.Offset == 0)
                    {
                        var array = source.Array;
                        for (var index = 0; index <= end; index++)
                        {
                            if (predicate.Invoke(array![index], index))
                                return true;
                        }
                    }
                    else
                    {
                        var array = source.Array;
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                        {
                            if (predicate.Invoke(array![index + offset], index))
                                return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

