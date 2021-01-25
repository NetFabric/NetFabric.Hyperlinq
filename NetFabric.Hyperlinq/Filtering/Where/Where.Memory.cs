using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this Memory<TSource> source, Func<TSource, bool> predicate)
            => source.Where(new FunctionWrapper<TSource, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ((ReadOnlyMemory<TSource>)source).Where(predicate);
    }
}

