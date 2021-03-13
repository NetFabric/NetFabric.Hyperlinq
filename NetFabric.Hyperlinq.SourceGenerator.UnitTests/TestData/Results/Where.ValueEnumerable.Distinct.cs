#nullable enable

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
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>, NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator, TSource> Distinct()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>, NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator, TSource>(this);

        }

    }
}
