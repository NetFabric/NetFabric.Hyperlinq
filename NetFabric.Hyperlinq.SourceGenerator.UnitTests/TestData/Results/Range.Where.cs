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
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int, NetFabric.Hyperlinq.FunctionWrapper<int, bool>> Where(System.Func<int, bool> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int>(this, predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int, TPredicate> Where<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, NetFabric.Hyperlinq.IFunction<int, bool>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int, TPredicate>(this, predicate);

        }

    }
}
