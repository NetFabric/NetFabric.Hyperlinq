namespace LinqBenchmarks;

public class ArrayInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
{
    protected int[] source;

    protected override void Setup()
    {
        base.Setup();
            
        source = GetRandomValues(Skip + Count);
    }
}