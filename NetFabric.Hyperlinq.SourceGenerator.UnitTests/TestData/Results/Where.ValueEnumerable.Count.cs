using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> where TEnumerable : notnull, NetFabric.Hyperlinq.IValueEnumerable<TSource, TEnumerator> where TEnumerator : struct, System.Collections.Generic.IEnumerator<TSource> where TPredicate : struct, NetFabric.Hyperlinq.IFunction<TSource, bool>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Count<NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>, NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.DisposableEnumerator, TSource>(this);

        }

    }
}
