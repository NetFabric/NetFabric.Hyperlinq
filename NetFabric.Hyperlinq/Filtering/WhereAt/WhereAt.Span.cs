using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereAtEnumerable<TSource, ValuePredicateAt<TSource>> Where<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => WhereAt((ReadOnlySpan<TSource>)source, predicate);
    }
}

