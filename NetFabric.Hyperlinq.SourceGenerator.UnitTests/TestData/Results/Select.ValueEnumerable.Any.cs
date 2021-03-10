#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Func<TResult, bool> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult>(this, predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, NetFabric.Hyperlinq.IFunction<TResult, bool>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult, TPredicate>(this, predicate);

        }

    }
}
