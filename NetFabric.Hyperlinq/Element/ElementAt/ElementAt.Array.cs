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
        public static ref readonly TSource ElementAt<TSource>(this TSource[] source, int index) 
            => ref index < 0 || index >= source.Length 
                ? ref Throw.ArgumentOutOfRangeExceptionRef<TSource>(nameof(index))
                : ref source[index];

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ref readonly TSource ElementAt<TSource>(this TSource[] source, int index, int skipCount, int takeCount) 
            => ref index < 0 || index >= takeCount 
                ? ref Throw.ArgumentOutOfRangeExceptionRef<TSource>(nameof(index))
                : ref source[index + skipCount];

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        public static ref readonly TSource ElementAtOrDefault<TSource>(this TSource[] source, int index) 
            => ref index < 0 || index >= source.Length
                ? ref Default<TSource>.Value
                : ref source[index];

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MaybeNull]
        static ref readonly TSource ElementAtOrDefault<TSource>(this TSource[] source, int index, int skipCount, int takeCount) 
            => ref index < 0 || index >= takeCount
                ? ref Default<TSource>.Value
                : ref source[index + skipCount];

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<TSource> TryElementAt<TSource>(this TSource[] source, int index) 
            => index < 0 || index >= source.Length 
                ? default
                : new Maybe<TSource>(source[index]);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Maybe<TSource> TryElementAt<TSource>(this TSource[] source, int index, int skipCount, int takeCount) 
            => index < 0 || index >= takeCount
                ? default
                : new Maybe<TSource>(source[index + skipCount]);
    }
}
