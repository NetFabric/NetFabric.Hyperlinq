using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

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
        static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
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
        static ref readonly TSource Single<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult Single<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Throw.EmptySequence<TResult>(),
                1 => selector(source[0]),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult Single<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Throw.EmptySequence<TResult>(),
                1 => selector(source[0], 0),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        static TResult Single<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate(source[index]))
                            Throw.NotSingleSequence();
                    }

                    return selector(first);
                }
            }
            return Throw.EmptySequence<TResult>();
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
        static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
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
        static ref readonly TSource SingleOrDefault<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate(source[index], index))
                            Throw.NotSingleSequence();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }

        [Pure]
        [return: MaybeNull]
        public static TResult SingleOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector) 
            => source.Length switch
            {
                0 => default,
                1 => selector(source[0]),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        [return: MaybeNull]
        public static TResult SingleOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector) 
            => source.Length switch
            {
                0 => default,
                1 => selector(source[0], 0),
                _ => Throw.NotSingleSequence<TResult>(),
            };

        [Pure]
        static TResult SingleOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly var first = ref source[index];

                    for (index++; index < source.Length; index++)
                    {
                        if (predicate(source[index]))
                            Throw.NotSingleSequence();
                    }

                    return selector(first);
                }
            }
            return default;
        }
    }
}
