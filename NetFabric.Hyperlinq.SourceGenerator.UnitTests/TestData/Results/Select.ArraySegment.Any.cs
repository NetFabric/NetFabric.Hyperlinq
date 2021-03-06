﻿#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public partial struct ArraySegmentSelectEnumerable<TSource, TResult, TSelector>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Func<TResult, bool> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyListExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult>(this, predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, NetFabric.Hyperlinq.IFunction<TResult, bool>
            => NetFabric.Hyperlinq.ValueReadOnlyListExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentSelectEnumerable<TSource, TResult, TSelector>, TResult, TPredicate>(this, predicate);

        }

    }
}
