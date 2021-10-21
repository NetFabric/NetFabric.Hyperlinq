// ReSharper disable LoopCanBeConvertedToQuery
namespace LinqBenchmarks.Enumerable.Int32;

public class EnumerableInt32Sum: EnumerableInt32BenchmarkBase
{
    Func<int> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Sum()
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public int ForeachLoop()
    {
        var sum = 0;
        foreach (var item in source)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Linq()
        => source.Sum();

    [Benchmark]
    public int LinqAF()
        => LinqAfExtensions.Sum(source);

    [Benchmark]
    public int LinqOptimizer()
        => linqOptimizerQuery.Invoke();

    [Benchmark]
    public int Streams()
        => source
            .AsStream()
            .Sum();

    [Benchmark]
    public int StructLinq()
        => source
            .ToStructEnumerable()
            .Sum();

    [Benchmark]
    public int StructLinq_ValueDelegate()
        => source
            .ToStructEnumerable()
            .Sum(x => x);

    [Benchmark]
    public int Hyperlinq()
        => source
            .AsValueEnumerable()
            .Sum();
}