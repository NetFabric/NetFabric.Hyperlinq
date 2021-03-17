namespace NetFabric.Hyperlinq.Benchmarks
{
    public abstract class RandomBenchmarksBase : CountBenchmarksBase
    {

        public override void GlobalSetup()
            => Initialize(Utils.GetRandomValues(seed, Count));
    }
}
