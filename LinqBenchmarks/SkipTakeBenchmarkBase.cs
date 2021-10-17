namespace LinqBenchmarks;

public class SkipTakeBenchmarkBase: BenchmarkBase
{
    [Params(1_000)]
    public int Skip { get; set; }
}