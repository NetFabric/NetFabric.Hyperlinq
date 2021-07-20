using System;
using System.Linq;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void Count_ArraySegmentValueEnumerable()
    {
        var array = Array.Empty<int>();

        _ = array.AsValueEnumerable().Count(_ => true);
    }
}
