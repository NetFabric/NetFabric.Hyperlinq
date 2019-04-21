using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static bool Any<TSource>(this Span<TSource> source)
            => source.Length != 0;

        public static bool Any<TSource>(this Span<TSource> source, Func<TSource, int, bool> predicate)
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

