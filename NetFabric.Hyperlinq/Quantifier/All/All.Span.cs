using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static bool All<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var index = 0;
            var length = source.Length;
            while (index < length && predicate(source[index]))
            {
                index++;
            }
            return index == length;
        }

        [Pure]
        public static bool All<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var index = 0;
            var length = source.Length;
            while (index < length && predicate(source[index], index))
            {
                index++;
            }
            return index == length;
        }
    }
}

