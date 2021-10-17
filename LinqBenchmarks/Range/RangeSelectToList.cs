namespace LinqBenchmarks.Range;

public partial class RangeSelectToList: RangeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public List<int> ForLoop()
    {
        var list = new List<int>();
        for (var index = 0; index < Count; index++)
            list.Add((index + Start) * 3);
        return list;
    }

    [Benchmark]
    public List<int> Linq()
        => System.Linq.Enumerable.Range(Start, Count).Select(item => item * 3).ToList();

    [Benchmark]
    public List<int> LinqFaster()
        => new(JM.LinqFaster.LinqFaster.RangeArrayF(Start, Count).SelectF(item => item * 3));

    [Benchmark]
    public List<int> LinqAF()
        => global::LinqAF.Enumerable.Range(Start, Count).Select(item => item * 3).ToList();

    [Benchmark]
    public List<int> StructLinq()
        => StructEnumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> StructLinq_ValueDelegate()
    {
        var selector = new TripleOfInt32();
        return StructEnumerable
            .Range(Start, Count)
            .Select(ref selector, x => x, x => x)
            .ToList(x => x);
    }

    [Benchmark]
    public List<int> Hyperlinq()
        => ValueEnumerable
            .Range(Start, Count)
            .Select(item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> Hyperlinq_ValueDelegate()
        => ValueEnumerable
            .Range(Start, Count)
            .Select<int, TripleOfInt32>()
            .ToList();

    [Benchmark]
    public List<int> Hyperlinq_SIMD()
        => ValueEnumerable
            .Range(Start, Count)
            .SelectVector(item => item * 3, item => item * 3)
            .ToList();

    [Benchmark]
    public List<int> Hyperlinq_ValueDelegate_SIMD()
        => ValueEnumerable
            .Range(Start, Count)
            .SelectVector<int, TripleOfInt32>()
            .ToList();
}