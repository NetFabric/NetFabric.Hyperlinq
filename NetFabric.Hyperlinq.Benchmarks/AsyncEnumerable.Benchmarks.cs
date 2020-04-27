using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class AsyncEnumerableBenchmarks
    {
        [Params(0, 10, 100, 10_000)]
        public int Count { get; set; }

        [BenchmarkCategory("Linq")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_AwaitForEach()
        {
            var sum = 0;
            await foreach (var item in System.Linq.AsyncEnumerable.Range(0, Count).ConfigureAwait(false))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Linq")]
        [Benchmark]
        public async ValueTask<int> Linq_Manual()
        {
            var sum = 0;
            var enumerator = System.Linq.AsyncEnumerable.Range(0, Count).GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    sum++;
            }
            return sum;
        }

        //[BenchmarkCategory("Hyperlinq")]
        //[Benchmark(Baseline = true)]
        //public async ValueTask<int> Hyperlinq_AwaitForEach()
        //{
        //    var sum = 0;
        //    await foreach (var item in AsyncEnumerable.Range(0, Count).ConfigureAwait(false))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("Hyperlinq")]
        //[Benchmark]
        //public async ValueTask<int> Hyperlinq_Manual()
        //{
        //    var sum = 0;
        //    var enumerator = AsyncEnumerable.Range(0, Count).GetAsyncEnumerator();
        //    await using (enumerator.ConfigureAwait(false))
        //    {
        //        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
        //            sum++;
        //    }
        //    return sum;
        //}

    }
}
