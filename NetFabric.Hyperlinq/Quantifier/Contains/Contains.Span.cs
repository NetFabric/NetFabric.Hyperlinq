using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static bool Contains<TSource>(this Span<TSource> source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            var length = source.Length;
            if (length == 0) return false;

            if (comparer is null)
            {
                for (var index = 0; index < length; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(value, source[index]))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index < length; index++)
                {
                    if (comparer.Equals(value, source[index]))
                        return true;
                }
            }

            return false;
        }

        public static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            var length = source.Length;
            if (length == 0) return false;

            if (comparer is null)
            {
                for (var index = 0; index < length; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(value, source[index]))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index < length; index++)
                {
                    if (comparer.Equals(value, source[index]))
                        return true;
                }
            }

            return false;
        }
    }
}

