using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class SkipBenchmarksBase : CountBenchmarksBase
    {
        [Params(100)]
        public int Skip { get; set; }
    }
}
