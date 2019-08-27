using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAt<TSource>(this TSource[] source, int index)
        {
            if (index < 0 || index >= source.Length) ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));

            return ref source[index];
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ref readonly TSource ElementAt<TSource>(this TSource[] source, int index, int skipCount, int takeCount)
        {
            if (index < 0 || index >= takeCount) ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));

            return ref source[index + skipCount];
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource ElementAtOrDefault<TSource>(this TSource[] source, int index)
        {

            if (index < 0 || index >= source.Length) return ref Default<TSource>.Value;

            return ref source[index];
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ref readonly TSource ElementAtOrDefault<TSource>(this TSource[] source, int index, int skipCount, int takeCount)
        {

            if (index < 0 || index >= takeCount) return ref Default<TSource>.Value;

            return ref source[index + skipCount];
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<TSource> TryElementAt<TSource>(this TSource[] source, int index)
        {
            if (index < 0 || index >= source.Length) return default;

            return new Maybe<TSource>(source[index]);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Maybe<TSource> TryElementAt<TSource>(this TSource[] source, int index, int skipCount, int takeCount)
        {
            if (index < 0 || index >= takeCount) return default;

            return new Maybe<TSource>(source[index + skipCount]);
        }
    }
}
