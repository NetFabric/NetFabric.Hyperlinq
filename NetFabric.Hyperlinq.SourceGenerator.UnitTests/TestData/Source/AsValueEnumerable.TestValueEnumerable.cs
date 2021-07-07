using System;
using System.Collections;
using System.Collections.Generic;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_ValueEnumerable()
    {
        // test calling AsValueEnumerable() on an IValueEnumerable
        _ = new TestValueEnumerable().AsValueEnumerable();
    }
}





