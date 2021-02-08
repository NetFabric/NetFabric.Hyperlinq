using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class ValueTypeListBenchmarkBase: BenchmarkBase
    {
        protected List<FatValueType> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = GetRandomValues(Count)
                .Select(value => new FatValueType(value))
                .ToList();
    }
}
