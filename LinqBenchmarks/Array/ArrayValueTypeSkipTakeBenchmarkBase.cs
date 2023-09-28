namespace LinqBenchmarks;

public class ValueTypeArraySkipTakeBenchmarkBase: SkipTakeBenchmarkBase
{
    protected FatValueType[] source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Skip + Count, Seed)
            .Select(value => new FatValueType(value))
            .ToArray();
    }
}