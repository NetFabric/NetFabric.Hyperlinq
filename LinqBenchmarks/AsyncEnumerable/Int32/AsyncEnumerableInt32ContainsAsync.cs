using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32;

public class AsyncEnumerableInt32ContainsAsync: AsyncEnumerableInt32BenchmarkBase
{
    int value = int.MaxValue;

    [Benchmark(Baseline = true)]
    public async ValueTask<bool> ForeachLoop()
    {
        await foreach (var item in source)
        {
            if (item == value)
                return true;
        }
        return true;
    }

    [Benchmark]
    public ValueTask<bool> Linq()
        => source.ContainsAsync(value);

    [Benchmark]
    public ValueTask<bool> Hyperlinq()
        => source
            .AsAsyncValueEnumerable()
            .ContainsAsync(value);
}