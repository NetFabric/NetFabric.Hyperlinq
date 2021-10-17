namespace LinqBenchmarks;

public class AsyncEnumerableInt32BenchmarkBase : BenchmarkBase
{
    protected IAsyncEnumerable<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.AsyncEnumerable<int>(Count);
    }
}