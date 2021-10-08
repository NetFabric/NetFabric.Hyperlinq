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
    public static AsValueEnumerable_TestEnumerableWithReferenceTypeEnumerator_TestValueType_ AsValueEnumerable(this TestEnumerableWithReferenceTypeEnumerator<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestEnumerableWithReferenceTypeEnumerator_TestValueType_
        : IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>
    {
        readonly TestEnumerableWithReferenceTypeEnumerator<TestValueType> source;

        internal AsValueEnumerable_TestEnumerableWithReferenceTypeEnumerator_TestValueType_(TestEnumerableWithReferenceTypeEnumerator<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueEnumerator<TestValueType> GetEnumerator() => new(source.GetEnumerator());

        IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
    }
}
