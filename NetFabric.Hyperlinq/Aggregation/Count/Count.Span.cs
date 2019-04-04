using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static int Count<TSource>(this Span<TSource> source)
            => source.Length;

        public static int Count<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                checked
                {                
                    if (predicate(source[index]))
                        count++;
                }
            }
            return count;
        }

        public static int Count<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length;

        public static int Count<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = 0;
            for (var index = 0; index < source.Length; index++)
            {
                checked
                {                
                    if (predicate(source[index]))
                        count++;
                }
            }
            return count;
        }

    }
}

