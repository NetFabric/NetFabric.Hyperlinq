using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class EmptyBenchmarks : BenchmarksBase
    {
        public override void GlobalSetup() { }

        [BenchmarkCategory("Empty")]
        [Benchmark(Baseline = true)]
        public int Linq_Empty()
        {
            var sum = 0;
            foreach (var item in Enumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty_Async")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_Empty_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.Empty<int>())
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Empty")]
        [Benchmark]
        public int Hyperlinq_Empty()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty_Async")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_Empty_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncValueEnumerable.Empty<int>())
                sum += item;
            return sum;
        }

    }
}