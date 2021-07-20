using System;
using System.Collections;
using System.Collections.Generic;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_TestEnumerableWithNoInterfaces()
    {
        // test calling AsValueEnumerable() for types that do not implement IEnumerable<>
        // but the public GetEnumerator() returns a type that doesn't implement IEnumerator<>

        _ = new TestEnumerableWithNoInterfaces<TestValueType>().AsValueEnumerable();
    }
}


