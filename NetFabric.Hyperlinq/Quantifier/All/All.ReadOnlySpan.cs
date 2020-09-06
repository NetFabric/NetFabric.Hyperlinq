using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return All(source, new ValuePredicate<TSource>(predicate));
        }
        
        public static bool All<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (!predicate.Invoke(source[index]))
                    return false;
            }
            return true;
        }

        public static bool All<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAt(source, new ValuePredicateAt<TSource>(predicate));
        }
        
        public static bool AllAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (!predicate.Invoke(source[index], index))
                    return false;
            }
            return true;
        }
    }
}

