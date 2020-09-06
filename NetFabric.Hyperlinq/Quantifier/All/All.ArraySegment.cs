using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                    {
                        if (!predicate.Invoke(item))
                            return false;
                    }
                }
                else
                {
                    var array = source.Array;
                    var end = source.Count + source.Offset - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        if (!predicate.Invoke(array![index]))
                            return false;
                    }
                }
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        if (!predicate.Invoke(item, index))
                            return false;

                        index++;
                    }
                }
                else
                {
                    var array = source.Array;
                    var end = source.Count + source.Offset - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        if (!predicate.Invoke(array![index], index))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}

