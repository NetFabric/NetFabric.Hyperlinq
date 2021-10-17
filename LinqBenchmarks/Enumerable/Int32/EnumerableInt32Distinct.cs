namespace LinqBenchmarks.Enumerable.Int32;

public class EnumerableInt32Distinct : EnumerableInt32BenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int ForeachLoop()
    {
        var set = new HashSet<int>();
        var sum = 0;
        foreach (var item in source)
        {
            if (set.Add(item))
                sum += item;
        }
        return sum;
    }

    [Benchmark]
    public int Linq()
    {
        var items = source
            .Distinct();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = global::LinqAF.IEnumerableExtensionMethods
            .Distinct(source);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq()
    {
        var items = source
            .ToStructEnumerable()
            .Distinct();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var comparer = new DefaultStructEqualityComparer();
        var items = source
            .ToStructEnumerable()
            .Distinct(comparer, x => x );
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

        
    [Benchmark]
    public int Hyperlinq()
    {
        var items = source.AsValueEnumerable().Distinct();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}