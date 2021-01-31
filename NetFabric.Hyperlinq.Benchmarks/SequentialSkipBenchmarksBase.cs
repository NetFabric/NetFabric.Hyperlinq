namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class SequentialSkipBenchmarksBase : SkipBenchmarksBase
    {
        public override void GlobalSetup()
            => Initialize(Utils.GetSequentialValues(Skip + Count));
    }
}
