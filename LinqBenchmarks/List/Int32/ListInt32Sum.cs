// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
namespace LinqBenchmarks.List.Int32;

public partial class ListInt32Sum: Int32ListBenchmarkBase
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
    public int ForLoop()
    {
        var sum = 0;
        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            sum += item;
        }
        return sum;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
    public int ForeachLoop()
    {
        var sum = 0;
        foreach (var item in source)
        {
            sum += item;
        }
        return sum;
    }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public int Linq()
        => System.Linq.Enumerable
            .Sum(source);

    [Benchmark]
    public int LinqFaster()
        => source
            .SumF();

    [Benchmark]
    public int LinqFasterer()
        => EnumerableF.SumF(source);

    [Benchmark]
    public int LinqAF()
        => global::LinqAF.ListExtensionMethods.Sum(source);

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