namespace LinqBenchmarks;

public class EnumerableInt32BenchmarkBase : BenchmarkBase
{
    protected IEnumerable<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.Enumerable<int>(Count);
    }
}