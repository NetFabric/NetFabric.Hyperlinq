using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(this Memory<TSource> source, Func<TSource, int, bool> predicate)
            => source.WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ((ReadOnlyMemory<TSource>)source).WhereAt(predicate);
    }
}

