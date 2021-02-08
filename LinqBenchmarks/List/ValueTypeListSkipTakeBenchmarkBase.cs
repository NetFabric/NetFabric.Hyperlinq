using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class ValueTypeListSkipTakeBenchmarkBase: SkipTakeBenchmarkBase
    {
        protected List<FatValueType> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = GetRandomValues(Skip + Count)
                .Select(value => new FatValueType(value))
                .ToList();
    }
}
