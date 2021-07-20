using System;
using System.Collections;
using System.Collections.Generic;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator()
    {
        // test calling AsValueEnumerable() for types that implement IEnumerable<>
        // but the public GetEnumerator() returns a type that doesn't implement IEnumerator<>

        _ = new TestEnumerableWithInterfacelessPublicEnumerator<TestValueType>().AsValueEnumerable();
    }
}





