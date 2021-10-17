namespace LinqBenchmarks.Enumerable.Int32;

public class EnumerableInt32SkipTakeSelect: EnumerableInt32SkipTakeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int Linq()
    {
        var sum = 0;
        foreach (var item in source.Skip(Skip).Take(Count).Select(item => item * 3))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var sum = 0;
        foreach (var item in global::LinqAF.IEnumerableExtensionMethods.Skip(source, Skip).Take(Count).Select(item => item * 3))
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
            .Select(item => item * 3)
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
            .Select(item => item * 3)
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
            .Select(item => item * 3))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var sum = 0;
        var selector = new TripleOfInt32();
        foreach (var item in source
            .ToStructEnumerable()
            .Skip(Skip, x=> x)
            .Take(Count, x => x)
            .Select(ref selector, x=> x, x => x))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var sum = 0;
        foreach (var item in source.AsValueEnumerable().Skip(Skip).Take(Count).Select(item => item * 3))
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var sum = 0;
        foreach (var item in source.AsValueEnumerable().Skip(Skip).Take(Count).Select<int, TripleOfInt32>())
            sum += item;
        return sum;
    }
}