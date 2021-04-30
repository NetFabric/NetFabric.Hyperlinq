using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace LinqBenchmarks
{
    public class AsyncEnumerableFatReferenceTypeBenchmarkBase : BenchmarkBase
    {
        protected IAsyncEnumerable<FatReferenceType> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Utils.AsyncEnumerable<FatReferenceType>(Count);
    }
}
