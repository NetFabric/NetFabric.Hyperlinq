using System;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void Count_SpanValueEnumerable()
    {
        var span = Array.Empty<int>().AsSpan();

#if !NOT_TESTING
        _ = span.AsValueEnumerable().Count(_ => true);
#endif
    }
}


