using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static bool Any<TSource>(this Span<TSource> source)
            => source.Length != 0;

        [Pure]
        public static bool Any<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        [Pure]
        public static bool Any<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

