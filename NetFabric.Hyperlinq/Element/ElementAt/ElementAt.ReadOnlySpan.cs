using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAt<TSource>(this ReadOnlySpan<TSource> source, int index) 
            => ref index < 0 || index >= source.Length ? 
                ref Throw.ArgumentOutOfRangeExceptionRef<TSource>(nameof(index)) : 
                ref source[index];

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ref readonly TSource ElementAt<TSource>(this ReadOnlySpan<TSource> source, int index, int skipCount, int takeCount) 
            => ref index < 0 || index >= takeCount ? 
                ref Throw.ArgumentOutOfRangeExceptionRef<TSource>(nameof(index)) : 
                ref source[index + skipCount];

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAtOrDefault<TSource>(this ReadOnlySpan<TSource> source, int index) 
            => ref index < 0 || index >= source.Length ? 
                ref Default<TSource>.Value : 
                ref source[index];

        [Pure]
        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ref readonly TSource ElementAtOrDefault<TSource>(this ReadOnlySpan<TSource> source, int index, int skipCount, int takeCount) 
            => ref index < 0 || index >= takeCount ? 
                ref Default<TSource>.Value : 
                ref source[index + skipCount];
    }
}
