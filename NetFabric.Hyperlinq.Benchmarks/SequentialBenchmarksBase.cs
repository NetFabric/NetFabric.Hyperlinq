using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class SequentialBenchmarksBase : CountBenchmarksBase
    {
        public override void GlobalSetup()
            => Initialize(Utils.GetSequentialValues(Count));
    }
}
