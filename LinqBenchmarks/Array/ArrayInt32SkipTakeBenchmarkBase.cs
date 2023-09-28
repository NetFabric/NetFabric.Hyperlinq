namespace LinqBenchmarks;

public class ArrayInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
{
    protected int[] source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Skip + Count, Seed);
    }
}