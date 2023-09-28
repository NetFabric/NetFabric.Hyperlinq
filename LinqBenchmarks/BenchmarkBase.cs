namespace LinqBenchmarks;

public class BenchmarkBase
{
    public int Seed = 42;

    [GlobalSetup]
    public void GlobalSetup()
        => Setup();
        
    protected virtual void Setup()
    {}

    [Params(100)]
    public int Count { get; set; }
}