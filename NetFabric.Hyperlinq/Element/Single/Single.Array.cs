using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource Single<TSource>(this TSource[] source)
            => ref Single<TSource>(source, 0, source.Length);

        [Pure]
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

        [Pure]
        public static ref readonly TSource Single<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref Single<TSource>(source, predicate, 0, source.Length);
        }
        [Pure]
        static ref readonly TSource Single<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
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

        [Pure]
        public static ref readonly TSource Single<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref Single<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static ref readonly TSource Single<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
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

        [Pure]
        public static ref readonly TSource Single<TSource>(this TSource[] source, PredicateAt<TSource> predicate, out int index)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref Single<TSource>(source, predicate, out index, 0, source.Length);
        }

        [Pure]
        static ref readonly TSource Single<TSource>(this TSource[] source, PredicateAt<TSource> predicate, out int index, int skipCount, int takeCount)
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

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source)
            => ref SingleOrDefault<TSource>(source, 0, source.Length);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
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

        [Pure]
        [return: MaybeNull]
        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref SingleOrDefault<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        [return: MaybeNull]
        static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
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

        [Pure]
        [return: MaybeNull]
        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref SingleOrDefault<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        [return: MaybeNull]
        static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
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

        [Pure]
        [return: MaybeNull]
        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, PredicateAt<TSource> predicate, out int index)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ref SingleOrDefault<TSource>(source, predicate, out index, 0, source.Length);
        }

        [Pure]
        [return: MaybeNull]
        static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, PredicateAt<TSource> predicate, out int index, int skipCount, int takeCount)
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
    }
}
