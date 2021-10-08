using System;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_Repeat()
    {
        // test calling AsValueEnumerable() for types that implement IValueEnumerable<,>

        _ = ValueEnumerable.Repeat(0, 100).AsValueEnumerable();
    }
}

