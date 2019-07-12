using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this TSource[] source)
            => ref Single<TSource>(source, 0, source.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ref readonly TSource Single<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            switch (takeCount)
            {
                case 0:
                    return ref ThrowHelper.ThrowEmptySequenceRef<TSource>();
                case 1:
                    return ref source[skipCount];
                default:
                    return ref ThrowHelper.ThrowNotSingleSequenceRef<TSource>();
            }
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref Single<TSource>(source, predicate, 0, source.Length);
        }
        static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                {
                    ref var first = ref source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref ThrowHelper.ThrowEmptySequenceRef<TSource>();
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref Single<TSource>(source, predicate, 0, source.Length);
        }

        static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                {
                    ref var first = ref source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref ThrowHelper.ThrowEmptySequenceRef<TSource>();
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref Single<TSource>(source, predicate, out index, 0, source.Length);
        }

        static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                {
                    ref var first = ref source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref ThrowHelper.ThrowEmptySequenceRef<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source)
            => ref SingleOrDefault<TSource>(source, 0, source.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            switch (takeCount)
            {
                case 0:
                    return ref Default<TSource>.Value;
                case 1:
                    return ref source[skipCount];
                default:
                    return ref ThrowHelper.ThrowNotSingleSequenceRef<TSource>();
            }
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref SingleOrDefault<TSource>(source, predicate, 0, source.Length);
        }

        static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref SingleOrDefault<TSource>(source, predicate, 0, source.Length);
        }

        static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref SingleOrDefault<TSource>(source, predicate, out index, 0, source.Length);
        }

        static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < end; index++)
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
        public static TSource? SingleOrNull<TSource>(this TSource[] source)
            where TSource : struct
            => SingleOrNull<TSource>(source, 0, source.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource? SingleOrNull<TSource>(this TSource[] source, int skipCount, int takeCount)
            where TSource : struct
        {
            switch (takeCount)
            {
                case 0:
                    return null;
                case 1:
                    return source[skipCount];
                default:
                    return ThrowHelper.ThrowNotSingleSequenceRef<TSource>();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            where TSource : struct
            => SingleOrNull<TSource>(source, predicate, out var _, 0, source.Length);

        public static TSource? SingleOrNull<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return SingleOrNull<TSource>(source, predicate, out index, 0, source.Length);
        }

        static TSource? SingleOrNull<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index, int skipCount, int takeCount)
            where TSource : struct
        {
            var end = skipCount + takeCount;
            for (index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                {
                    var first = source[index];

                    for (index++; index < end; index++)
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
