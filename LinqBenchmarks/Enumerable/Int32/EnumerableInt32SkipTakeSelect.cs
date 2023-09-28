// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable LoopCanBeConvertedToQuery
namespace LinqBenchmarks.Enumerable.Int32;

public class EnumerableInt32SkipTakeSelect: EnumerableInt32SkipTakeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int Linq()
    {
        var items = source.Skip(Skip).Take(Count).Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = LinqAfExtensions.Skip(source, Skip).Take(Count).Select(item => item * 3);
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
            .Skip(Skip)
            .Take(Count)
            .Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int StructLinq_ValueDelegate()
    {
        var selector = new TripleOfInt32();
        var items = source
            .ToStructEnumerable()
            .Skip(Skip, x => x)
            .Take(Count, x => x)
            .Select(ref selector, x => x, x => x);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var items = source.AsValueEnumerable().Skip(Skip).Take(Count).Select(item => item * 3);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var items = source.AsValueEnumerable().Skip(Skip).Take(Count).Select<int, TripleOfInt32>();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}