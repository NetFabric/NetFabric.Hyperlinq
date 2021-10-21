namespace LinqBenchmarks.Enumerable.FatReferenceType;

public class EnumerableFatReferenceTypeAny: EnumerableFatReferenceTypeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public bool ForeachLoop()
    {
        foreach (var _ in source)
        {
            return true;
        }

        return false;
    }
        
    [Benchmark]
    public bool Linq()
        => source.Any();

    [Benchmark]
    public bool LinqAF()
        => LinqAfExtensions.Any(source);

    [Benchmark]
    public bool StructLinq()
        => source
            .ToStructEnumerable()
            .Any();

    [Benchmark]
    public bool StructLinq_ValueDelegate()
        => source
            .ToStructEnumerable()
            .Any();

    [Benchmark]
    public bool Hyperlinq()
        => source
            .AsValueEnumerable()
            .Any();
}