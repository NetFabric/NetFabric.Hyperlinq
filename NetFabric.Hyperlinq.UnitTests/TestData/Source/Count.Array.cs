using System;
using System.Linq;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void Count_ArraySegmentValueEnumerable()
    {
        _ = Array.Empty<TestValueType>()
            .AsValueEnumerable()
            .Count(_ => true);
    }
}
