using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereAtEnumerable<TSource, ValuePredicateAt<TSource>> Where<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => WhereAt(new ArraySegment<TSource>(source), predicate);
    }
}

