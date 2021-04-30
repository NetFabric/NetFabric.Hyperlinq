using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32
{
    public class AsyncEnumerableInt32WhereSelect: AsyncEnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async ValueTask<int> ForeachLoop()
        {
            var sum = 0;
            await foreach (var item in source)
            {
                if (item.IsEven())
                    sum += item * 3;
            }
            return sum;
        }

        [Benchmark]
        public async ValueTask<int> Linq()
        {
            var items = source
                .Where(item => item.IsEven())
                .Select(item => item * 3);
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public async ValueTask<int> Hyperlinq()
        {
            var items = source.AsAsyncValueEnumerable()
                .Where((item, _) => new ValueTask<bool>(item.IsEven()))
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
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>();
            var sum = 0;
            await foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}
