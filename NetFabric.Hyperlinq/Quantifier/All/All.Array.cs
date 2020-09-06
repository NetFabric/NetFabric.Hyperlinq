using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => All(new ArraySegment<TSource>(source), predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => AllAt(new ArraySegment<TSource>(source), predicate);
    }
}

