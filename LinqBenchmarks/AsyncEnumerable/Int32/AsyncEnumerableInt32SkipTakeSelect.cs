using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32
{
    public class AsyncEnumerableInt32SkipTakeSelect: AsyncEnumerableInt32SkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq()
        {
            var items = source.Skip(Skip).Take(Count).Select(item => item * 3);
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
                .Skip(Skip)
                .Take(Count)
                .Select<int, TripleOfInt32>();
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}
