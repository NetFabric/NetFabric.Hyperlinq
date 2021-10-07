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

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_<TestEnumerableWithValueTypeEnumerator<TestValueType>> AsValueEnumerable(this TestEnumerableWithValueTypeEnumerator<TestValueType> source)
        //    => new(source, source);

        //public readonly struct AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_<TEnumerable>
        //    : IValueEnumerable<TestValueType, TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator>
        //    where TEnumerable : IEnumerable<TestValueType>
        //{
        //    readonly TestEnumerableWithValueTypeEnumerator<TestValueType> source;
        //    readonly TEnumerable source2;

        //    internal AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_(TestEnumerableWithValueTypeEnumerator<TestValueType> source, TEnumerable source2)
        //        => (this.source, this.source2) = (source, source2);

        //    // Implement IValueEnumerable<TestValueType, TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator>

        //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        //    public TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

        //    IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => source2.GetEnumerator();

        //    IEnumerator IEnumerable.GetEnumerator() => source2.GetEnumerator();
        //}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableExtensions.SelectEnumerable<GeneratedExtensionMethods.AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_<TestEnumerableWithValueTypeEnumerator<TestValueType>>, TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator, TestValueType, TestReferenceType, NetFabric.Hyperlinq.FunctionWrapper<TestValueType, TestReferenceType>> Select(this GeneratedExtensionMethods.AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_<TestEnumerableWithValueTypeEnumerator<TestValueType>> source, System.Func<TestValueType, TestReferenceType> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<GeneratedExtensionMethods.AsValueEnumerable_TestEnumerableWithValueTypeEnumerator_TestValueType_<TestEnumerableWithValueTypeEnumerator<TestValueType>>, TestEnumerableWithValueTypeEnumerator<TestValueType>.Enumerator, TestValueType, TestReferenceType, NetFabric.Hyperlinq.FunctionWrapper<TestValueType, TestReferenceType>>(source, selector);
    }
}
