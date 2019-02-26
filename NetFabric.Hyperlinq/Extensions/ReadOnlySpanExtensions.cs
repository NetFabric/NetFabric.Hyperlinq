using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        public static int Count<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length;

        public static int Count<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static ReadOnlySpan<TSource> Skip<TSource>(this ReadOnlySpan<TSource> source, int count)
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

        public static ReadOnlySpan<TSource> Take<TSource>(this ReadOnlySpan<TSource> source, int count)
        {
            if (count <= 0)
                return source.Slice(0, 0);

            var length = source.Length;
            return source.Slice(0, (count < length) ? count : length);
        }

        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static bool Any<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length != 0;

        public static bool Any<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => source.Contains(value, comparer);

        public static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source)
        {
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source)
        {
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static TSource? FirstOrNull<TSource>(this ReadOnlySpan<TSource> source)
            where TSource : struct
        {
            if (source.Length == 0) return null;

            return source[0];
        }

        public static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static TSource? FirstOrNull<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source)
        {
            var length = source.Length;
            if (length == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source)
        {
            var length = source.Length;
            if (length == 0) return ref Default<TSource>.Value;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static TSource? SingleOrNull<TSource>(this ReadOnlySpan<TSource> source)
            where TSource : struct
        {
            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static TSource? SingleOrNull<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static List<TSource> ToList<TSource>(this ReadOnlySpan<TSource> source)
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
