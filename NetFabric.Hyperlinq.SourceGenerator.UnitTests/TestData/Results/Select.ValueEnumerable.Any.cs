using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> where TEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TSource, TEnumerator> where TEnumerator : struct, System.Collections.Generic.IEnumerator<TSource> where TSelector : struct, NetFabric.Hyperlinq.IFunction<TSource, TResult>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Func<TResult, bool> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult>(this, predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, NetFabric.Hyperlinq.IFunction<TResult, bool>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator, TResult, TPredicate>(this, predicate);

        }

    }
}
