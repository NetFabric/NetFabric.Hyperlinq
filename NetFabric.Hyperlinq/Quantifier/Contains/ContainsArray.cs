using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static bool Contains<TSource>(this TSource[] source, TSource value)
            => System.Array.IndexOf<TSource>(source, value) >= 0;

        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource> comparer)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));

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

