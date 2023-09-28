namespace LinqBenchmarks.ImmutableArray.Int32;

public class ImmutableArrayInt32Where: ImmutableArrayInt32BenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int ForLoop()
    {
        var sum = 0;
        var array = source;
        for (var index = 0; index < array.Length; index++)
        {
            var item = array[index];
            if (item.IsEven())
                sum += item;
        }
        return sum;
    }

    [Benchmark]
    public int ForeachLoop()
    {
        var sum = 0;
        foreach (var item in source)
        {
            if (item.IsEven())
                sum += item;
        }
        return sum;
    }

    [Benchmark]
    public int Linq()
    {
        var items = source.Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqFasterer()
    {
        var items = EnumerableF.WhereF(source, item => item.IsEven());
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
            .Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var predicate = new Int32IsEven();
        var items = source
            .ToStructEnumerable()
            .Where(ref predicate, x => x);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var items = source.AsValueEnumerable()
            .Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable()
            .Where<Int32IsEven>();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}