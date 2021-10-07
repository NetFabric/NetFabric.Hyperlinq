#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class GeneratedExtensionMethods
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NetFabric.Hyperlinq.ValueReadOnlyListExtensions.SelectEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType, TestReferenceType, NetFabric.Hyperlinq.FunctionWrapper<TestValueType, TestReferenceType>> Select(this NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType> source, System.Func<TestValueType, TestReferenceType> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType, TestReferenceType>(source, selector);
    }
}
