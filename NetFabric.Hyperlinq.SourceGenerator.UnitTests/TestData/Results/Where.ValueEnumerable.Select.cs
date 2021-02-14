using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>, NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator, TSource, TResult, NetFabric.Hyperlinq.FunctionWrapper<TSource, TResult>> Select<TResult>(System.Func<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>, NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator, TSource, TResult>(this, selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>, NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator, TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
            where TSelector : struct, NetFabric.Hyperlinq.IFunction<TSource, TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>, NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator, TSource, TResult, TSelector>(this, selector);

        }

    }
}
