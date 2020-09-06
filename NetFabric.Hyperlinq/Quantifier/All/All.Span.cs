using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => All((ReadOnlySpan<TSource>)source, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => AllAt((ReadOnlySpan<TSource>)source, predicate);
    }
}

