using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (!predicate(source[index], index))
                    return false;
            }
            return true;
        }
    }
}

