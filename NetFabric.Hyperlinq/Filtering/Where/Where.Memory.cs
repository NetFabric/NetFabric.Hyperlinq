using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource, ValuePredicate<TSource>> Where<TSource>(this Memory<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Where(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => Where((ReadOnlyMemory<TSource>)source, predicate);
    }
}

