using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace LinqBenchmarks
{
    public class AsyncEnumerableInt32BenchmarkBase : BenchmarkBase
    {
        protected IAsyncEnumerable<int> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Utils.AsyncEnumerable<int>(Count);
    }
}
