using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class SingleBenchmarksBase : BenchmarksBase
    {
        public override void GlobalSetup()
            => Initialize(new[] { 42 });
    }
}
