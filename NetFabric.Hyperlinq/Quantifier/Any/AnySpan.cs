using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static bool Any<TSource>(this Span<TSource> source)
            => source.Length != 0;

        public static bool Any<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return false;

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        public static bool Any<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length != 0;

        public static bool Any<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return false;

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }
    }
}

