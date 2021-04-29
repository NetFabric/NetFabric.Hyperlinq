using BenchmarkDotNet.Attributes;

namespace LinqBenchmarks
{
    public class ArrayInt32BenchmarkBase : BenchmarkBase
    {
        protected int[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = GetRandomValues(Count);
    }
}
