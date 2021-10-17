using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32;

public class AsyncEnumerableInt32WhereCountAsync: AsyncEnumerableInt32BenchmarkBase
{
    [Benchmark(Baseline = true)]
    public async ValueTask<int> ForeachLoop()
    {
        var count = 0;
        await foreach (var item in source)
        {
            if (item.IsEven())
                count++;
        }
        return count;
    }

    [Benchmark]
    public ValueTask<int> Linq()
        => source.CountAsync(item => item.IsEven());

    [Benchmark]
    public ValueTask<int> Hyperlinq()
        => source.AsAsyncValueEnumerable()
            .Where((item, _) => new ValueTask<bool>(item.IsEven()))
            .CountAsync();

    [Benchmark]
    public ValueTask<int> Hyperlinq_ValueDelegate()
        => source.AsAsyncValueEnumerable()
            .Where<Int32IsEven>()
            .CountAsync();
}