using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
            => source.Where(new FunctionWrapper<TSource, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => ((ReadOnlySpan<TSource>)source).Where(predicate);
    }
}

