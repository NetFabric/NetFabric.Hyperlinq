#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq;

static partial class GeneratedExtensionMethods
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType> Skip(this NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType> source, int count)
        => NetFabric.Hyperlinq.ValueReadOnlyListExtensions.Skip<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType>(source, count);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType> Take(this NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType> source, int count)
        => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Take<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType>(source, count);
}
