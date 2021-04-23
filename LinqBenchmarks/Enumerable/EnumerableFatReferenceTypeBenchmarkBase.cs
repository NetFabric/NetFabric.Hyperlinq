using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace LinqBenchmarks
{
    public class EnumerableFatReferenceTypeBenchmarkBase : BenchmarkBase
    {
        protected IEnumerable<FatReferenceType> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Utils.Enumerable<FatReferenceType>(Count);
    }
}
