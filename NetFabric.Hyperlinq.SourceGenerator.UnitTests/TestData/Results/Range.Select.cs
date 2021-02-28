#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public partial struct RangeEnumerable
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int, TResult, NetFabric.Hyperlinq.FunctionWrapper<int, TResult>> Select<TResult>(System.Func<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int, TResult>(this, selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
            where TSelector : struct, NetFabric.Hyperlinq.IFunction<int, TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int, TResult, TSelector>(this, selector);

        }

    }
}
