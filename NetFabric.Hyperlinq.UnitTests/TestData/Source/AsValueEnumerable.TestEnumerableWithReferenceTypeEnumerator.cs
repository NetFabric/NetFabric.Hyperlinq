using System;
using System.Collections;
using System.Collections.Generic;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_TestEnumerableWithReferenceTypeEnumerator()
    {
        // test calling AsValueEnumerable() for types that implement IEnumerable<> and the enumerator is not a value type

        _ = new TestEnumerableWithReferenceTypeEnumerator<TestValueType>().AsValueEnumerable();
    }
}





