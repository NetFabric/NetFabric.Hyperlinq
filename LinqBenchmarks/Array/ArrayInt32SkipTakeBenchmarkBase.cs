using BenchmarkDotNet.Attributes;

namespace LinqBenchmarks
{
    public class ArrayInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
    {
        protected int[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = GetRandomValues(Skip + Count);
    }
}
