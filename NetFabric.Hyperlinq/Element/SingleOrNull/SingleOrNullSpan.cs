using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static TSource? SingleOrNull<TSource>(this Span<TSource> source)
            where TSource : struct
        {
            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        public static TSource? SingleOrNull<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }

        public static TSource? SingleOrNull<TSource>(this ReadOnlySpan<TSource> source)
            where TSource : struct
        {
            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        public static TSource? SingleOrNull<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }
    }
}
