namespace LinqBenchmarks.Range;

public partial class RangeToList: RangeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public List<int> ForLoop()
    {
        var list = new List<int>();
        for (var index = 0; index < Count; index++)
            list.Add(index + Start);
        return list;
    }

    [Benchmark]
    public List<int> Linq()
        => System.Linq.Enumerable
            .Range(Start, Count).ToList();

    [Benchmark]
    public List<int> LinqFaster()
        => new(JM.LinqFaster.LinqFaster
            .RangeArrayF(Start, Count));

    [Benchmark]
    public List<int> LinqAF()
        => global::LinqAF.Enumerable
            .Range(Start, Count).ToList();

    [Benchmark]
    public List<int> StructLinq()
        => StructEnumerable
            .Range(Start, Count)
            .ToList(x => x);

    [Benchmark]
    public List<int> Hyperlinq()
        => ValueEnumerable
            .Range(Start, Count)
            .ToList();
}