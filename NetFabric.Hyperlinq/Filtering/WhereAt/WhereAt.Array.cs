using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            => source.WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new ArraySegment<TSource>(source).WhereAt(predicate);
    }
}

