#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {

        [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
        [DebuggerNonUserCode]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count(this NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable source)
        => NetFabric.Hyperlinq.ValueEnumerableExtensions.Count<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable, NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator, int>(source);

    }
}
