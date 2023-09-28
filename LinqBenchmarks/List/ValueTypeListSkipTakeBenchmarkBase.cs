namespace LinqBenchmarks;

public class ValueTypeListSkipTakeBenchmarkBase: SkipTakeBenchmarkBase
{
    protected List<FatValueType> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Skip + Count, Seed)
            .Select(value => new FatValueType(value))
            .ToList();
    }
}