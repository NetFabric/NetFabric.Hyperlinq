using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static ref TSource First<TSource>(this TSource[] source)
        {
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Length;
            if (count == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source)
        {
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Length;
            if (count == 0) return ref Default<TSource>.Value;

            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }
        
        public static TSource? FirstOrNull<TSource>(this TSource[] source)
            where TSource : struct
        {
            if (source.Length == 0) return null;

            return source[0];
        }

        public static TSource? FirstOrNull<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Length;
            if (count == 0) return null;
            
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }
    }
}
