using System;
using System.Collections;
using System.Collections.Generic;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_EnumerableWithValueTypeEnumerator()
    {
        // test calling AsValueEnumerable() for types that implement IEnumerable<> and the enumerator is a value type

        _ = new TestEnumerableWithValueTypeEnumerator<TestValueType>().AsValueEnumerable();
    }
}





