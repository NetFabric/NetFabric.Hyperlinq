using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        /////////////////
        // ElementAt

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAt<TSource>(this ReadOnlySpan<TSource> source, int index) 
            => ref index < 0 || index >= source.Length ? 
                ref Throw.ArgumentOutOfRangeExceptionRef<TSource>(nameof(index)) : 
                ref source[index];

        [Pure]
        static ref readonly TSource ElementAt<TSource>(this ReadOnlySpan<TSource> source, int index, Predicate<TSource> predicate) 
        {
            if (index >= 0)
            {
                for (var itemIndex = 0; itemIndex < source.Length; itemIndex++)
                {
                    if (predicate(source[itemIndex]) && index-- == 0)
                        return ref source[itemIndex];
                }
            }
            return ref Throw.ArgumentOutOfRangeExceptionRef<TSource>(nameof(index));
        }

        [Pure]
        static ref readonly TSource ElementAt<TSource>(this ReadOnlySpan<TSource> source, int index, PredicateAt<TSource> predicate) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    if (predicate(source[sourceIndex], sourceIndex) && index-- == 0)
                        return ref source[sourceIndex];
                }
            }
            return ref Throw.ArgumentOutOfRangeExceptionRef<TSource>(nameof(index));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult ElementAt<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, Selector<TSource, TResult> selector) 
            => index < 0 || index >= source.Length ? 
                Throw.ArgumentOutOfRangeException<TResult>(nameof(index)) : 
                selector(source[index]);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ElementAt<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, SelectorAt<TSource, TResult> selector) 
            => index < 0 || index >= source.Length ? 
                Throw.ArgumentOutOfRangeException<TResult>(nameof(index)) : 
                selector(source[index], index);

        [Pure]
        static TResult ElementAt<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    if (predicate(source[sourceIndex]) && index-- == 0)
                        return selector(source[sourceIndex]);
                }
            }
            return Throw.ArgumentOutOfRangeException<TResult>(nameof(index));
        }

        /////////////////
        // ElementAtOrDefault

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAtOrDefault<TSource>(this ReadOnlySpan<TSource> source, int index) 
            => ref index < 0 || index >= source.Length ? 
                ref Default<TSource>.Value : 
                ref source[index];

        [Pure]
        static ref readonly TSource ElementAtOrDefault<TSource>(this ReadOnlySpan<TSource> source, int index, Predicate<TSource> predicate) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    if (predicate(source[sourceIndex]) && index-- == 0)
                        return ref source[sourceIndex];
                }
            }
            return ref Default<TSource>.Value;
        }    

        [Pure]
        static ref readonly TSource ElementAtOrDefault<TSource>(this ReadOnlySpan<TSource> source, int index, PredicateAt<TSource> predicate) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    if (predicate(source[sourceIndex], sourceIndex) && index-- == 0)
                        return ref source[sourceIndex];
                }
            }
            return ref Default<TSource>.Value;
        }    

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult ElementAtOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, Selector<TSource, TResult> selector) 
            => index < 0 || index >= source.Length ? 
                default : 
                selector(source[index]);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ElementAtOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, SelectorAt<TSource, TResult> selector) 
            => index < 0 || index >= source.Length ? 
                default : 
                selector(source[index], index);

        [Pure]
        static TResult ElementAtOrDefault<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    if (predicate(source[sourceIndex]) && index-- == 0)
                        return selector(source[sourceIndex]);
                }
            }
            return Default<TResult>.Value;
        }
    }
}
