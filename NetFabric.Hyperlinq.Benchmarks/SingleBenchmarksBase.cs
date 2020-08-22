using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class SingleBenchmarksBase : BenchmarksBase
    {
        [Params(1)]
        public int Count { get; set; }

        public override void GlobalSetup()
            => Initialize(new[] { 42 });
    }
}
