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
    public static AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_ AsValueEnumerable(this TestEnumerableWithValueTypeEnumerator<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_
        : IValueEnumerable<TestValueType, TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator>
    {
        readonly TestEnumerableWithValueTypeEnumerator<TestValueType> source;

        internal AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_(TestEnumerableWithValueTypeEnumerator<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

        IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
