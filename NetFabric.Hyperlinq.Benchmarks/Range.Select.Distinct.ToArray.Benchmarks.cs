using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Buffers;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MemoryDiagnoser]
    public class RangeSelectDistinctToArrayBenchmarks
    {
        [Params(0, 1, 10, 100)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public int[] Linq()
            => Enumerable.Range(0, Count).Select(item => item % 10).Distinct().ToArray();

        [Benchmark]
        public int[] Hyperlinq()
            => ValueEnumerable.Range(0, Count).Select(item => item % 10).Distinct().ToArray();

        [Benchmark]
        public IMemoryOwner<int> Hyperlinq_Pool()
            => ValueEnumerable.Range(0, Count).Select(item => item % 10).Distinct().ToArray(MemoryPool<int>.Shared);
    }
}
