using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MemoryDiagnoser]
    public class RangeSelectDistinctToListBenchmarks
    {
        [Params(0, 1, 10, 100)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public List<int> Linq()
            => Enumerable.Range(0, Count).Select(item => item % 10).Distinct().ToList();

        [Benchmark]
        public List<int> Hyperlinq()
            => ValueEnumerable.Range(0, Count).Select(item => item % 10).Distinct().ToList();
    }
}
