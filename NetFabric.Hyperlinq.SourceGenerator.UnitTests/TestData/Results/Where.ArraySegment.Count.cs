#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public partial struct ArraySegmentWhereEnumerable<TSource, TPredicate>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Count<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentWhereEnumerable<TSource, TPredicate>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentWhereEnumerable<TSource, TPredicate>.DisposableEnumerator, TSource>(this);

        }

    }
}
