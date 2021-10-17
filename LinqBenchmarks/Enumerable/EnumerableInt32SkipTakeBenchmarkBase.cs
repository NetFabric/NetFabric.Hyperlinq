namespace LinqBenchmarks;

public class EnumerableInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
{
    protected IEnumerable<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.Enumerable<int>(Skip + Count);
    }
}