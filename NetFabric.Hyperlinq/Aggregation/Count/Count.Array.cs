using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        public static int Count<TSource>(this TSource[] source, Func<TSource, bool> predicate)
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

