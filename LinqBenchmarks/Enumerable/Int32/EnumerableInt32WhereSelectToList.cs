namespace LinqBenchmarks.Enumerable.Int32;

public partial class EnumerableInt32WhereSelectToList: EnumerableInt32BenchmarkBase
{
    Func<List<int>> linqOptimizerQuery;

    protected override void Setup()
    {
        base.Setup();

        linqOptimizerQuery = source
            .AsQueryExpr()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList()
            .Compile();
    }

    [Benchmark(Baseline = true)]
    public List<int> ForeachLoop()
    {
        var list = new List<int>();
        foreach (var item in source)
        {
            if (item.IsEven())
                list.Add(item * 3);
        }
        return list;
    }

    [Benchmark]
    public List<int> Linq()
        => source
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> LinqAF()
        => LinqAfExtensions
            .Where(source, item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> LinqOptimizer()
        => linqOptimizerQuery.Invoke();

    [Benchmark]
    public List<int> Streams()
        => source
            .AsStream()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> StructLinq()
        => source
            .ToStructEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> StructLinq_ValueDelegate()
    {
        var predicate = new Int32IsEven();
        var selector = new TripleOfInt32();
        return source
            .ToStructEnumerable()
            .Where(ref predicate, x => x)
            .Select(ref selector, x => x, x => x)
            .ToList(x => x);
    }

    [Benchmark]
    public List<int> Hyperlinq()
        => source.AsValueEnumerable()
            .Where(item => item.IsEven())
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> Hyperlinq_ValueDelegate()
        => source.AsValueEnumerable()
            .Where<Int32IsEven>()
            .Select<int, TripleOfInt32>()
            .ToList();
}