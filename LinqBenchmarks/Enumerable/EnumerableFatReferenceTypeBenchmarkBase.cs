namespace LinqBenchmarks;

public class EnumerableFatReferenceTypeBenchmarkBase : BenchmarkBase
{
    protected IEnumerable<FatReferenceType> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.Enumerable<FatReferenceType>(Count);
    }
}