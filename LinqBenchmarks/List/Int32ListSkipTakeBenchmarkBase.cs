namespace LinqBenchmarks;

public class Int32ListSkipTakeBenchmarkBase : SkipTakeBenchmarkBase
{
    protected List<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Skip + Count, Seed).ToList();
    }
}