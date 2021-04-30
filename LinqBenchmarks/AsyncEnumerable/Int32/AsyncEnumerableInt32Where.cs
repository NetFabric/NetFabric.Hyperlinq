using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32
{
    public class AsyncEnumerableInt32Where: AsyncEnumerableInt32BenchmarkBase
    {
        [BenchmarkCategory("Enumerable", "Int32")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq()
        {
            var sum = 0;
            await foreach (var item in source.Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public async ValueTask<int> Hyperlinq()
        {
            var items = source.AsAsyncValueEnumerable()
                .Where((item, _) => new ValueTask<bool>(item.IsEven()));
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public async ValueTask<int> Hyperlinq_ValueDelegate()
        {
            var items = source.AsAsyncValueEnumerable()
                .Where<Int32IsEven>();
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}
