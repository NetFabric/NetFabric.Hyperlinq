using NetFabric.Hyperlinq;
using System.Collections.Generic;

partial class TestsSource
{
    static void AsValueEnumerable_IReadOnlyList()
    {
        // test calling AsValueEnumerable() on an IReadOnlyList<>
        IReadOnlyList<TestValueType> list = new TestReadOnlyList<TestValueType>();
        _ = list.AsValueEnumerable();
    }
}





