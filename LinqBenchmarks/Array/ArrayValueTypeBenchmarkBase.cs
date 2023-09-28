namespace LinqBenchmarks;

public class ValueTypeArrayBenchmarkBase: BenchmarkBase
{
    protected FatValueType[] source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Count, Seed)
            .Select(value => new FatValueType(value))
            .ToArray();
    }
}