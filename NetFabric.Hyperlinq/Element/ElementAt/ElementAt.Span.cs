using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Span
    {
        [Pure]
        public static ref readonly TSource ElementAt<TSource>(this Span<TSource> source, int index)
        {
            if (index < 0 || index >= source.Length) Throw.ArgumentOutOfRangeException<TSource>(nameof(index));

            return ref source[index];
        }

        [Pure]
        static ref readonly TSource ElementAt<TSource>(this Span<TSource> source, int index, int skipCount, int takeCount)
        {
            if (index < 0 || index >= takeCount) Throw.ArgumentOutOfRangeException<TSource>(nameof(index));

            return ref source[index + skipCount];
        }

        [Pure]
        [return: MaybeNull]
        public static ref readonly TSource ElementAtOrDefault<TSource>(this Span<TSource> source, int index)
        {

            if (index < 0 || index >= source.Length) return ref Default<TSource>.Value;

            return ref source[index];
        }

        [Pure]
        [return: MaybeNull]
        static ref readonly TSource ElementAtOrDefault<TSource>(this Span<TSource> source, int index, int skipCount, int takeCount)
        {

            if (index < 0 || index >= takeCount) return ref Default<TSource>.Value;

            return ref source[index + skipCount];
        }
    }
}
