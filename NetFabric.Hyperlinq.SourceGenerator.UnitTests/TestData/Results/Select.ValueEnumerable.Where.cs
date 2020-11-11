using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public readonly partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> where TEnumerable : notnull, NetFabric.Hyperlinq.IValueEnumerable<TSource, TEnumerator> where TEnumerator : struct, System.Collections.Generic.IEnumerator<TSource> where TSelector : struct, NetFabric.Hyperlinq.IFunction<TSource, TResult>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult, NetFabric.Hyperlinq.FunctionWrapper<TResult, bool>> Where(System.Func<TResult, bool> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult>(this, predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult, TPredicate> Where<TPredicate>(TPredicate predicate)
            where TPredicate : struct, NetFabric.Hyperlinq.IFunction<TResult, bool>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult, TPredicate>(this, predicate);
        }

    }
}
