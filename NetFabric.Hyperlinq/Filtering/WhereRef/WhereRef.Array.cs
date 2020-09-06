using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefEnumerable<TSource, ValuePredicate<TSource>> WhereRef<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereRef(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => WhereRef(new ArraySegment<TSource>(source), predicate);
    }
}

