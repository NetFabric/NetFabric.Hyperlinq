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
        public static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source) 
            => ref source.Length == 0 
                ? ref Throw.EmptySequenceRef<TSource>()
                : ref source[0];

        [Pure]
        static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Throw.EmptySequenceRef<TSource>();
        }

        [Pure]
        static ref readonly TSource First<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            return ref Throw.EmptySequenceRef<TSource>();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult First<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Throw.EmptySequence<TResult>(),
                _ => selector(source[0]),
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult First<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => Throw.EmptySequence<TResult>(),
                _ => selector(source[0], 0),
            };

        [Pure]
        static  TResult First<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return selector(source[index]);
            }
            return Throw.EmptySequence<TResult>();
        }

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source) 
            => ref source.Length == 0 
                ? ref Default<TSource>.Value
                : ref source[0];

        [Pure]
        [return: MaybeNull]
        static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        [Pure]
        [return: MaybeNull]
        static ref readonly TSource FirstOrDefault<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult FirstOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
            => source.Length switch
            {
                0 => default,
                _ => selector(source[0]),
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult FirstOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
            => source.Length switch
            {
                0 => default,
                _ => selector(source[0], 0),
            };

        [Pure]
        static TResult FirstOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return selector(source[index]);
            }
            return default;
        }    
    }
}
