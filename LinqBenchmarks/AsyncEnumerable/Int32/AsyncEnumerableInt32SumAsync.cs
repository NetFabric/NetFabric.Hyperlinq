using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32
{
    public class AsyncEnumerableInt32SumAsync: AsyncEnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async ValueTask<int> ForeachLoop()
        {
            var sum = 0;
            await foreach (var item in source)
                sum += item;
            return sum;
        }

        [Benchmark]
        public ValueTask<int> Linq()
            => source.SumAsync();

        [Benchmark]
        public ValueTask<int> Hyperlinq()
            => source
                .AsAsyncValueEnumerable()
                .SumAsync();
    }
}
