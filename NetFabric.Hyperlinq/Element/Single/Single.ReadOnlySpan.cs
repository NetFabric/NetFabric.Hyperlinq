using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source)
        {
            switch (source.Length)
            {
                case 0:
                    return ref Throw.EmptySequenceRef<TSource>();
                case 1:
                    return ref source[0];
                default:
                    return ref Throw.NotSingleSequenceRef<TSource>();
            }
        }

        [Pure]
        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            Throw.NotSingleSequence();
                    }

                    return ref first;
                }
            }
            return ref Throw.EmptySequenceRef<TSource>();
        }

        [Pure]
        public static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index], index))
                            Throw.NotSingleSequence();
                    }

                    return ref first;
                }
            }
            return ref Throw.EmptySequenceRef<TSource>();
        }

        [Pure]
        [return: MaybeNull]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source)
        {
            switch (source.Length)
            {
                case 0:
                    return ref Default<TSource>.Value;
                case 1:
                    return ref source[0];
                default:
                    return ref Throw.NotSingleSequenceRef<TSource>();
            }
        }

        [Pure]
        [return: MaybeNull]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            Throw.NotSingleSequence();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }

        [Pure]
        [return: MaybeNull]
        public static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index], index))
                            Throw.NotSingleSequence();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }
    }
}
