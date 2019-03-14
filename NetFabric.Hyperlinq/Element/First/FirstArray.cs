using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static ref readonly TSource First<TSource>(this TSource[] source)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Length;
            if (count == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref Default<TSource>.Value;
        }
    }
}
