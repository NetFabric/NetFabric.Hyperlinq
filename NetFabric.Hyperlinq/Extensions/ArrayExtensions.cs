using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        public static ref readonly TSource First<TSource>(this TSource[] source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (source.Length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return ref Default<TSource>.Value;
            if (source.Length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static TSource[] ToArray<TSource>(this TSource[] source) 
            => source;

        static class Default<T>
        {
            static readonly T value = default;

            public static ref readonly T Value => ref value;
        }
    }
}
