using System;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static int Count<TSource>(this Span<TSource> source)
            => source.Length;


        [Pure]
        public static int Count<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }


        [Pure]
        public static int Count<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    count++;
            }
            return count;
        }
    }
}

