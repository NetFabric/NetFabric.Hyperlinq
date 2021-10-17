namespace LinqBenchmarks;

public class ValueTypeArraySkipTakeBenchmarkBase: SkipTakeBenchmarkBase
{
    protected FatValueType[] source;

    protected override void Setup()
    {
        base.Setup();
            
        source = GetRandomValues(Skip + Count)
            .Select(value => new FatValueType(value))
            .ToArray();
    }
}