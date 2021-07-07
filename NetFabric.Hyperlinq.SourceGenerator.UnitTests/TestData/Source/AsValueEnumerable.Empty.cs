using System;
//using NetFabric.Hyperlinq; => DO NOT UNCOMMENT

partial class TestsSource
{
    static void AsValueEnumerable_Empty()
    {
        // test calling AsValueEnumerable() for types that don't need source generation
        // with NetFabric.Hyperlinq namespace NOT in a using clause 

        var array = Array.Empty<int>();

#if !NOT_TESTING
        _ = array.AsValueEnumerable();
        _ = new ArraySegment<int>(array).AsValueEnumerable();

        _ = array.AsMemory().AsValueEnumerable();
        _ = ((ReadOnlyMemory<int>)array.AsMemory()).AsValueEnumerable();

        _ = array.AsSpan().AsValueEnumerable();
        _ = ((ReadOnlySpan<int>)array.AsSpan()).AsValueEnumerable();
#endif
    }
}

