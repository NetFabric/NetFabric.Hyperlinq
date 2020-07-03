using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MemoryDiagnoser]
    public class RangeWhereSelectToArrayBenchmarks
    {
        [Params(0, 1, 10, 100)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public int[] Linq()
            => Enumerable.Range(0, Count).Where(item => (item & 0x01) == 0).Select(item => item * 2).ToArray();

        [Benchmark]
        public int[] Hyperlinq()
            => ValueEnumerable.Range(0, Count).Where(item => (item & 0x01) == 0).Select(item => item * 2).ToArray();
    }
}
