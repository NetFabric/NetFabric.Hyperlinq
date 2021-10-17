using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32;

public class AsyncEnumerableInt32Distinct : AsyncEnumerableInt32BenchmarkBase
{
    [Benchmark(Baseline = true)]
    public async ValueTask<int> ForeachLoop()
    {
        var set = new HashSet<int>();
        var sum = 0;
        await foreach (var item in source)
        {
            if (set.Add(item))
                sum += item;
        }
        return sum;
    }

    [Benchmark]
    public async ValueTask<int> Linq()
    {
        var sum = 0;
        await foreach (var item in source.Distinct())
            sum += item;
        return sum;
    }
        
    [Benchmark]
    public async ValueTask<int> Hyperlinq()
    {
        var sum = 0;
        await foreach (var item in source.AsAsyncValueEnumerable().Distinct())
            sum += item;
        return sum;
    }
}