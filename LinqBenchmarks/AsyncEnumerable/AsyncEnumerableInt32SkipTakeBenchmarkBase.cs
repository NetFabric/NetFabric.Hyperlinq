namespace LinqBenchmarks;

public class AsyncEnumerableInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
{
    protected IAsyncEnumerable<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.AsyncEnumerable<int>(Skip + Count);
    }
}