using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public readonly partial struct DistinctEnumerable<TEnumerable, TEnumerator, TSource> where TEnumerable : notnull, NetFabric.Hyperlinq.IValueEnumerable<TSource, TEnumerator> where TEnumerator : struct, System.Collections.Generic.IEnumerator<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>, NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator, TSource, NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>> Where(System.Func<TSource, bool> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>, NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator, TSource>(this, predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>, NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator, TSource, TPredicate> Where<TPredicate>(TPredicate predicate)
            where TPredicate : struct, NetFabric.Hyperlinq.IFunction<TSource, bool>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>, NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator, TSource, TPredicate>(this, predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>, NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator, TSource> Distinct()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>, NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator, TSource>(this);

        }

    }
}
