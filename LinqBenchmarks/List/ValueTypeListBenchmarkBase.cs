namespace LinqBenchmarks;

public class ValueTypeListBenchmarkBase: BenchmarkBase
{
    protected List<FatValueType> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = GetRandomValues(Count)
            .Select(value => new FatValueType(value))
            .ToList();
    }
}