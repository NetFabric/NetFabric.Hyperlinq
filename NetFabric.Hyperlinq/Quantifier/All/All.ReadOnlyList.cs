using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TList, TSource>(source, predicate, 0, source.Count);
        }

        
        internal static bool All<TList, TSource>(this TList source, Predicate<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, PredicateAt<TSource> predicate)
            where TList : IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TList, TSource>(source, predicate, 0, source.Count);
        }

        
        internal static bool All<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var end = count - 1;
            if (offset == 0)
            {
                for (var index = 0; index <= end; index++)
                {
                    if (!predicate(source[index], index))
                        return false;
                }
            }
            else
            {
                for (var index = 0; index <= end; index++)
                {
                    if (!predicate(source[index + offset], index))
                        return false;
                }
            }
            return true;
        }
    }
}

