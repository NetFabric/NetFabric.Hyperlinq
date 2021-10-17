using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32;

public class AsyncEnumerableInt32Select: AsyncEnumerableInt32BenchmarkBase
{
    [Benchmark(Baseline = true)]
    public async ValueTask<int> ForeachLoop()
    {
        var sum = 0;
        await foreach (var item in source)
            sum += item * 3;
        return sum;
    }

    [Benchmark]
    public async ValueTask<int> Linq()
    {
        var items = source.Select(item => item * 3);
        var sum = 0;
        await foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public async ValueTask<int> Hyperlinq()
    {
        var items = source.AsAsyncValueEnumerable()
            .Select((item, _) => new ValueTask<int>(item * 3));
        var sum = 0;
        await foreach (var item in items)
            sum += item;
        return sum;
    }

    [Benchmark]
    public async ValueTask<int> Hyperlinq_ValueDelegate()
    {
        var items = source.AsAsyncValueEnumerable()
            .Select<int, TripleOfInt32>();
        var sum = 0;
        await foreach (var item in items)
            sum += item;
        return sum;
    }
}