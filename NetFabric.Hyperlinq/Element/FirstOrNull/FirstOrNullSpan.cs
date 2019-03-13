using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static TSource? FirstOrNull<TSource>(this Span<TSource> source)
            where TSource : struct
        {
            if (source.Length == 0) return null;

            return source[0];
        }

        public static TSource? FirstOrNull<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }

        public static TSource? FirstOrNull<TSource>(this ReadOnlySpan<TSource> source)
            where TSource : struct
        {
            if (source.Length == 0) return null;

            return source[0];
        }

        public static TSource? FirstOrNull<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }
    }
}
