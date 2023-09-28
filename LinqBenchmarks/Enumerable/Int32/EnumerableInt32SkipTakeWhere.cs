// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
namespace LinqBenchmarks.Enumerable.Int32;

[BenchmarkCategory("Enumerable", "Int32")]
public class EnumerableInt32SkipTakeWhere: EnumerableInt32SkipTakeBenchmarkBase
{
    [Benchmark(Baseline = true)]
    public int Linq()
    {
        var items = source.Skip(Skip).Take(Count).Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int LinqAF()
    {
        var items = LinqAfExtensions.Skip(source, Skip).Take(Count)
            .Where(item => item.IsEven());
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
            .Skip(Skip, x => x)
            .Take(Count, x => x)
            .Where(ref predicate, x => x);
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq()
    {
        var items = source
            .AsValueEnumerable()
            .Skip(Skip)
            .Take(Count)
            .Where(item => item.IsEven());
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Hyperlinq_ValueDelegate()
    {
        var items = source
            .AsValueEnumerable()
            .Skip(Skip)
            .Take(Count)
            .Where<Int32IsEven>();
        var sum = 0;
        foreach (var item in items)
            sum += item;
        return sum;
    }
}