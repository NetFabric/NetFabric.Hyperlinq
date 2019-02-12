using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        public static ref readonly TSource First<TSource>(this TSource[] source)
        {
            if (source == null) ThrowSourceNull();
            if (source.Length == 0) ThrowEmptySequence();

            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source)
        {
            if (source == null) ThrowSourceNull();
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowSourceNull();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowEmptySequence();
            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowSourceNull();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source)
        {
            if (source == null) ThrowSourceNull();
            if (source.Length == 0) ThrowEmptySequence();
            if (source.Length > 1) ThrowNotSingleSequence();

            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source)
        {
            if (source == null) ThrowSourceNull();
            if (source.Length == 0) return ref Default<TSource>.Value;
            if (source.Length > 1) ThrowNotSingleSequence();

            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowSourceNull();
            if (source.Length > 1) ThrowNotSingleSequence();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowEmptySequence();
            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowSourceNull();
            if (source.Length > 1) ThrowNotSingleSequence();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
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
