using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static int Count<TSource>(this Span<TSource> source)
            => source.Length;


        public static int Count<TSource>(this Span<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                unchecked // always less than source.Length
                {                
                    if (predicate(source[index], index))
                        count++;
                }
            }
            return count;
        }
    }
}

