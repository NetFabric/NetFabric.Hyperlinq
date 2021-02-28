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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this NetFabric.Hyperlinq.ValueEnumerable.RepeatEnumerable<TSource> source)
        => NetFabric.Hyperlinq.ValueEnumerableExtensions.Count<NetFabric.Hyperlinq.ValueEnumerable.RepeatEnumerable<TSource>, NetFabric.Hyperlinq.ValueEnumerable.RepeatEnumerable<TSource>.DisposableEnumerator, TSource>(source);

    }
}
