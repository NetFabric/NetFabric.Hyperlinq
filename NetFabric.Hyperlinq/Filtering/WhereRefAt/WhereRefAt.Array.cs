using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefAtEnumerable<TSource, ValuePredicateAt<TSource>> WhereRef<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereRefAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefAtEnumerable<TSource, TPredicate> WhereRefAt<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => WhereRefAt(new ArraySegment<TSource>(source), predicate);
    }
}

