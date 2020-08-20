using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class CountBenchmarksBase : BenchmarksBase
    {
        [Params(100)]
        public int Count { get; set; }

        public override void GlobalSetup() { }
    }
}
