using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource, ValuePredicate<TSource>> Where<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Where(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => Where(new ArraySegment<TSource>(source), predicate);
    }
}

