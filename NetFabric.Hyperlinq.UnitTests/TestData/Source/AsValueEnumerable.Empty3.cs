using System;
using System.Linq;
using NetFabric.Hyperlinq; // namespace is known at compile time 

partial class TestsSource
{
    static void AsValueEnumerable_Empty3()
    {
        var valueEnumerable = Array
            .Empty<int>()
            .AsValueEnumerable();

        _ = Enumerable.Count(valueEnumerable);
        _ = Enumerable.Count(valueEnumerable, _ => true);
        _ = Enumerable.Take(Enumerable.Skip(valueEnumerable, 1), 2);
    }
}

