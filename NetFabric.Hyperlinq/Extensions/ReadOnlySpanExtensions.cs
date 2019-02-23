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
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

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

        public static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

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
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

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
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (source.Length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return ref Default<TSource>.Value;
            if (source.Length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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

        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
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
