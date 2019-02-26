using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static int Count<TSource>(this Span<TSource> source)
            => source.Length;

        public static int Count<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return 0;

            var count = 0;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static Span<TSource> Skip<TSource>(this Span<TSource> source, int count)
        {
            if (count <= 0)
                return source;

            var length = source.Length;
            var start = count < length ? count : length;
            var newCount = length - count;
            if (newCount < 0)
                newCount = 0;
            return source.Slice(start, newCount);
        }

        public static Span<TSource> Take<TSource>(this Span<TSource> source, int count)
        {
            if (count <= 0)
                return source.Slice(0, 0);

            var length = source.Length;
            return source.Slice(0, (count < length) ? count : length);
        }

        public static bool All<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
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

        public static bool Any<TSource>(this Span<TSource> source)
            => source.Length != 0;

        public static bool Any<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return false;

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        public static bool Contains<TSource>(this Span<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this Span<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => source.Contains(value, comparer);

        public static ref readonly TSource First<TSource>(this Span<TSource> source)
        {
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source)
        {
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static TSource? FirstOrNull<TSource>(this Span<TSource> source)
            where TSource : struct
        {
            if (source.Length == 0) return null;

            return source[0];
        }

        public static ref readonly TSource First<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static TSource? FirstOrNull<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }

        public static ref readonly TSource Single<TSource>(this Span<TSource> source)
        {
            var length = source.Length;
            if (length == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source)
        {
            var length = source.Length;
            if (length == 0) return ref Default<TSource>.Value;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static TSource? SingleOrNull<TSource>(this Span<TSource> source)
            where TSource : struct
        {
            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        public static ref readonly TSource Single<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static TSource? SingleOrNull<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }

        public static List<TSource> ToList<TSource>(this Span<TSource> source)
        {
            var length = source.Length;
            var list = new List<TSource>(length);
            for(var index = 0; index < length; index++)
            {
                list.Add(source[index]);
            }
            return list;
        }    
    }
}
