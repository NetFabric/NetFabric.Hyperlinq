using System.Collections.Immutable;

namespace LinqBenchmarks;

public class ImmutableArrayInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
{
    protected ImmutableArray<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Skip + Count, Seed).ToImmutableArray();
    }
}