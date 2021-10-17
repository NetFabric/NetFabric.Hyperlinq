namespace LinqBenchmarks.Array.Int32;

public class ArrayInt32Distinct : BenchmarkBase
{
    int[] source;

    [Params(4)]
    public int Duplicates { get; set; }

    protected override void Setup()
    {
        base.Setup();
            
        source = System.Linq.Enumerable
            .SelectMany(
                System.Linq.Enumerable.Range(0, Duplicates),
                _ => System.Linq.Enumerable.Range(0, Count))
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var set = new HashSet<int>();
        var sum = 0;
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            var item = array[index];
            if (set.Add(item))
                sum += item;
        }
        return sum;
    }

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
    public int LinqFasterer()
    {
        var items = EnumerableF
            .DistinctF(source);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = global::LinqAF.ArrayExtensionMethods
            .Distinct(source);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq()
    {
        var items = source.ToStructEnumerable()
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
        var distinct = source.ToStructEnumerable()
            .Distinct(comparer, x => x);
        var sum = 0;
        foreach (var item in distinct)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var items = source.AsValueEnumerable()
            .Distinct();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}