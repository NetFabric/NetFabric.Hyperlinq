using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source)
        {
            var length = source.Length;
            if (length == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        [Pure]
        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        [Pure]
        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        [Pure]
        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate, out int index)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source)
        {
            var length = source.Length;
            if (length == 0) return ref Default<TSource>.Value;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        [Pure]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }

        [Pure]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }

        [Pure]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate, out int index)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            index = -1;
            return ref Default<TSource>.Value;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TSource>(this ReadOnlySpan<TSource> source)
            where TSource : struct
        {
            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => SingleOrNull<TSource>(source, predicate, out var _);

        [Pure]
        public static TSource? SingleOrNull<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, long, bool> predicate, out int index)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    var first = source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return first;
                }
            }
            index = -1;
            return null;
        }
    }
}
