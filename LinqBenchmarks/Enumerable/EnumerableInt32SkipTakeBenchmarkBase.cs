namespace LinqBenchmarks;

public class EnumerableInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
{
    protected IEnumerable<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = new EnumerableWrapper<int>(Utils.GetRandomValues(Skip + Count, Seed));
    }
}