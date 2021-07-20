using System;
using System.Collections;
using System.Collections.Generic;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose()
    {
        // test calling AsValueEnumerable() for types that do not implement IEnumerable<>
        // and the public GetEnumerator() returns a type that implement IDisposable and has a Reset() method

        _ = new TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType>().AsValueEnumerable();
    }
}





