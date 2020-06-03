using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TList, TSource>(source, predicate, 0, source.Count);
        }

        
        internal static bool All<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, PredicateAt<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TList, TSource>(source, predicate, 0, source.Count);
        }

        
        internal static bool All<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (!predicate(source[index], index))
                        return false;
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (!predicate(source[index + skipCount], index))
                        return false;
                }
            }
            return true;
        }
    }
}

