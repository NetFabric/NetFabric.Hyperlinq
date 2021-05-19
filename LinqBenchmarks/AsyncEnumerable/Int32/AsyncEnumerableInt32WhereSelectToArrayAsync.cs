using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.Int32
{
    public partial class AsyncEnumerableInt32WhereSelectToArrayAsync: AsyncEnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async ValueTask<int[]> ForeachLoop()
        {
            var list = new List<int>();
            await foreach (var item in source)
            {
                if (item.IsEven())
                    list.Add(item * 3);
            }
            return list.ToArray();
        }

        [Benchmark]
        public ValueTask<int[]> Linq()
            => source
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArrayAsync();

        [Benchmark]
        public ValueTask<int[]> Hyperlinq()
            => source.AsAsyncValueEnumerable()
                .Where((item, _) => new ValueTask<bool>(item.IsEven()))
                .Select((item, _) => new ValueTask<int>(item * 3))
                .ToArrayAsync();

        [Benchmark]
        public ValueTask<int[]> Hyperlinq_ValueDelegate()
            => source.AsAsyncValueEnumerable()
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>()
                .ToArrayAsync();
    }
}
