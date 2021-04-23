using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace LinqBenchmarks
{
    public class EnumerableInt32BenchmarkBase : BenchmarkBase
    {
        protected IEnumerable<int> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Utils.Enumerable<int>(Count);
    }
}
