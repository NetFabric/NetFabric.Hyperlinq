using BenchmarkDotNet.Attributes;
using System.Linq;

namespace LinqBenchmarks
{
    public class ArrayInt32BenchmarkBase : BenchmarkBase
    {
        protected int[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = System.Linq.Enumerable.Range(0, Count).ToArray();
    }
}
