using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> WhereRef<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            => source.WhereRefAt(new FunctionWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereRefAtEnumerable<TSource, TPredicate> WhereRefAt<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new ArraySegment<TSource>(source).WhereRefAt(predicate);
    }
}

