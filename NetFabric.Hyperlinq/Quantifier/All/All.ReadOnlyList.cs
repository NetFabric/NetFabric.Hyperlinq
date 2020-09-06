using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All<TList, TSource, ValuePredicate<TSource>>(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => All<TList, TSource, TPredicate>(source, predicate, 0, source.Count);

        
        internal static bool All<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (!predicate.Invoke(source[index]))
                    return false;
            }
            return true;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TList, TSource>(this TList source, PredicateAt<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAt<TList, TSource, ValuePredicateAt<TSource>>(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
            => AllAt<TList, TSource, TPredicate>(source, predicate, 0, source.Count);
        
        internal static bool AllAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var end = count - 1;
            if (offset == 0)
            {
                for (var index = 0; index <= end; index++)
                {
                    if (!predicate.Invoke(source[index], index))
                        return false;
                }
            }
            else
            {
                for (var index = 0; index <= end; index++)
                {
                    if (!predicate.Invoke(source[index + offset], index))
                        return false;
                }
            }
            return true;
        }
    }
}

