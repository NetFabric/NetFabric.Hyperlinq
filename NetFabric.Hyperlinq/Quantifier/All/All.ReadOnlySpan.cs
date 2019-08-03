using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            var index = 0;
            var length = source.Length;
            while (index < length && predicate(source[index]))
            {
                index++;
            }
            return index == length;
        }

        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate)
        {
            var index = 0;
            var length = source.Length;
            while (index < length && predicate(source[index], index))
            {
                index++;
            }
            return index == length;
        }
    }
}

