namespace LinqBenchmarks.List.Int32;

public class ListInt32Distinct: BenchmarkBase
{
    List<int> source;
    List<int> sourceLinqFaster;

    [Params(4)]
    public int Duplicates { get; set; }

    protected override void Setup()
    {
        base.Setup();
            
        var items = System.Linq.Enumerable
            .SelectMany(
                System.Linq.Enumerable.Range(0, Duplicates),
                _ => System.Linq.Enumerable.Range(0, Count));

        source = items.ToList();
        sourceLinqFaster = items.ToList();
    }

    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var set = new HashSet<int>();
        var sum = 0;
        for (var index = 0; index < source.Count; index++)
        {
            var item = source[index];
            if (set.Add(item))
                sum += item;
        }
        return sum;
    }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
    [Benchmark]
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
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

    [Benchmark]
    public int Linq()
    {
        var items = source.Distinct();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFaster()
    {
        if (Count is not 0)
            sourceLinqFaster.DistinctInPlaceF();
        var sum = 0;
        foreach (var item in sourceLinqFaster)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFasterer()
    {
        var items = EnumerableF.DistinctF(source);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = global::LinqAF.ListExtensionMethods.Distinct(source);
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