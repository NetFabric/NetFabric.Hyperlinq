using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace LinqBenchmarks
{
    public class EnumerableInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
    {
        protected IEnumerable<int> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Utils.Enumerable<int>(Skip + Count);
    }
}
