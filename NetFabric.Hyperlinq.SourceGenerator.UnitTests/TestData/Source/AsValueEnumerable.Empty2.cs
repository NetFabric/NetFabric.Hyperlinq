using System;
using System.Collections.Generic;
using NetFabric.Hyperlinq; // namespace is known at compile time 

partial class TestsSource
{
    static void AsValueEnumerable_Empty2()
    {
        // test calling AsValueEnumerable() for types that don't need source generation

        var array = Array.Empty<int>();

        _ = array.AsValueEnumerable();
        _ = ArrayExtensions.AsValueEnumerable(array);
        _ = new ArraySegment<int>(array).AsValueEnumerable();

        _ = array.AsMemory().AsValueEnumerable();
        _ = ((ReadOnlyMemory<int>)array.AsMemory()).AsValueEnumerable();

        _ = array.AsSpan().AsValueEnumerable();
        _ = ((ReadOnlySpan<int>)array.AsSpan()).AsValueEnumerable();

        var list = new List<int>();
        _ = list.AsValueEnumerable();
    }
}

