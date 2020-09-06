using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource, ValuePredicateAt<TSource>> Where<TSource>(this Memory<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => WhereAt((ReadOnlyMemory<TSource>)source, predicate);
    }
}

