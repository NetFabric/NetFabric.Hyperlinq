using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TSource Single<TSource>(this Span<TSource> source)
        {
            var length = source.Length;
            if (length == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref TSource Single<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    ref var first = ref source[index];

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

        public static ref TSource Single<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref var first = ref source[index];

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

        public static ref TSource Single<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate, out int index)
        {
            var length = source.Length;
            for (index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref var first = ref source[index];

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source)
        {
            var length = source.Length;
            if (length == 0) return ref Default<TSource>.Value;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
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

        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
        {
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

        public static ref readonly TSource SingleOrDefault<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate, out int index)
        {
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TSource>(this Span<TSource> source)
            where TSource : struct
        {
            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => SingleOrNull<TSource>(source, predicate, out var _);

        public static TSource? SingleOrNull<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate, out int index)
            where TSource : struct
        {
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
