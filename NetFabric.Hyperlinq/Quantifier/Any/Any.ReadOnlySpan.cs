using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        public static bool Any<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length != 0;

        public static bool Any<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate)
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

