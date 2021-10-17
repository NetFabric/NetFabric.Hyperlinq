namespace LinqBenchmarks;

public class AsyncEnumerableFatReferenceTypeBenchmarkBase : BenchmarkBase
{
    protected IAsyncEnumerable<FatReferenceType> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.AsyncEnumerable<FatReferenceType>(Count);
    }
}