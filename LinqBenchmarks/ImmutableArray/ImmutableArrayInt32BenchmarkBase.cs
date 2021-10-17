using System.Collections.Immutable;

namespace LinqBenchmarks;

public class ImmutableArrayInt32BenchmarkBase : BenchmarkBase
{
    protected ImmutableArray<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = GetRandomValues(Count).ToImmutableArray();
    }
}