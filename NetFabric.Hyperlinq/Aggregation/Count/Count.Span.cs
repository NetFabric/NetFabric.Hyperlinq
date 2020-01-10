using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static int Count<TSource>(this Span<TSource> source)
            => source.Length;

        [Pure]
        public static int Count<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        [Pure]
        public static int Count<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var count = 0;
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                var result = predicate(source[index], index);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }
    }
}

