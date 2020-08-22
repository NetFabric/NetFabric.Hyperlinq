namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class RandomSkipBenchmarksBase : SkipBenchmarksBase
    {
        public override void GlobalSetup()
            => Initialize(GetRandomValues(Skip + Count));
    }
}
