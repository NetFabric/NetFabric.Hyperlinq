namespace LinqBenchmarks.Enumerable.Int32;

[BenchmarkCategory("Enumerable", "Int32")]
public class EnumerableInt32SkipTakeWhere: EnumerableInt32SkipTakeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int Linq()
    {
        var sum = 0;
        foreach (var item in source.Skip(Skip).Take(Count).Where(item => item.IsEven()))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var sum = 0;
        foreach (var item in global::LinqAF.IEnumerableExtensionMethods.Skip(source, Skip).Take(Count).Where(item => item.IsEven()))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqOptimizer()
    {
        var sum = 0;
        foreach (var item in source
            .AsQueryExpr()
            .Skip(Skip)
            .Take(Count)
            .Where(item => item.IsEven())
            .Run())
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Streams()
    {
        var sum = 0;
        foreach (var item in source
            .AsStream()
            .Skip(Skip)
            .Take(Count)
            .Where(item => item.IsEven())
            .ToEnumerable())
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq()
    {
        var sum = 0;
        foreach (var item in source
            .ToStructEnumerable()
            .Skip(Skip)
            .Take(Count)
            .Where(item => item.IsEven()))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var sum = 0;
        var predicate = new Int32IsEven();
        foreach (var item in source
            .ToStructEnumerable()
            .Skip(Skip, x=> x)
            .Take(Count, x => x)
            .Where(ref predicate, x => x))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var sum = 0;
        foreach (var item in source.AsValueEnumerable()
            .Skip(Skip)
            .Take(Count)
            .Where(item => item.IsEven()))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var sum = 0;
        foreach (var item in source.AsValueEnumerable()
            .Skip(Skip)
            .Take(Count)
            .Where<Int32IsEven>())
            sum += item;
        return sum;
    }
}