using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32
{
    [BenchmarkCategory("Enumerable", "Int32")]
    public class AsyncEnumerableInt32SkipTakeWhere: AsyncEnumerableInt32SkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq()
        {
            var items = source
                .Skip(Skip)
                .Take(Count)
                .Where(item => item.IsEven());
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public async ValueTask<int> Hyperlinq()
        {
            var items = source.AsAsyncValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where(item => item.IsEven());
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public async ValueTask<int> Hyperlinq_ValueDelegate()
        {
            var items = source.AsAsyncValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where<Int32IsEven>();
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}
