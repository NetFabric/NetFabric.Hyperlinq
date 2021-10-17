namespace LinqBenchmarks;

public class ValueTypeArrayBenchmarkBase: BenchmarkBase
{
    protected FatValueType[] source;

    protected override void Setup()
    {
        base.Setup();
            
        source = GetRandomValues(Count)
            .Select(value => new FatValueType(value))
            .ToArray();
    }
}