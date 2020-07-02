using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool All<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Offset == 0 && source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (!predicate(array[index]))
                            return false;
                    }
                }
                else
                {
                    var end = source.Offset + source.Count;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (!predicate(array[index]))
                            return false;
                    }
                }
            }
            return true;
        }

        public static bool All<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
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
                            if (!predicate(array[index], index))
                                return false;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < source.Count; index++)
                        {
                            if (!predicate(array[index], index))
                                return false;
                        }
                    }
                }
                else
                {
                    var offset = source.Offset;
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (!predicate(array[index + offset], index))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}

