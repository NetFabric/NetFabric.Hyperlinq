using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return false;

            for (var index = 0; index < length; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }
    }
}

