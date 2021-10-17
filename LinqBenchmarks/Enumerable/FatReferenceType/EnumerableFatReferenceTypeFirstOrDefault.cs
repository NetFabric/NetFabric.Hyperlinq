namespace LinqBenchmarks.Enumerable.FatReferenceType;

public class EnumerableFatReferenceTypeFirstOrDefault: EnumerableFatReferenceTypeBenchmarkBase
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
        => source.FirstOrDefault() is not null;

    [Benchmark]
    public bool LinqAF()
        => global::LinqAF.IEnumerableExtensionMethods.FirstOrDefault(source) is not null;

    [Benchmark]
    public bool StructLinq()
        => source
            .ToStructEnumerable()
            .FirstOrDefault() is not null;

    [Benchmark]
    public bool StructLinq_ValueDelegate()
        => source
            .ToStructEnumerable()
            .FirstOrDefault(x => x) is not null;

    [Benchmark]
    public bool Hyperlinq()
        => source
            .AsValueEnumerable()
            .FirstOrDefault() is not null;
}