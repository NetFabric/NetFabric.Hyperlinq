using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        [Pure]
        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var index = 0;
            var length = source.Length;
            while (index < length && predicate(source[index]))
            {
                index++;
            }
            return index == length;
        }

        [Pure]
        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

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

