using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereEnumerable<TSource, ValuePredicate<TSource>> Where<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Where(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => Where((ReadOnlySpan<TSource>)source, predicate);
    }
}

