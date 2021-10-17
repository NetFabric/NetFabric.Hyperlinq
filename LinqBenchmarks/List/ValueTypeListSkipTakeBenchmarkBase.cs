namespace LinqBenchmarks;

public class ValueTypeListSkipTakeBenchmarkBase: SkipTakeBenchmarkBase
{
    protected List<FatValueType> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = GetRandomValues(Skip + Count)
            .Select(value => new FatValueType(value))
            .ToList();
    }
}