using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static ref readonly TSource First<TSource>(this Span<TSource> source)
        {
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource First<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source)
        {
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }
    }
}
