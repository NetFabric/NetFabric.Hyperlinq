using BenchmarkDotNet.Attributes;
using System.Linq;

namespace LinqBenchmarks
{
    public class ValueTypeArrayBenchmarkBase: BenchmarkBase
    {
        protected FatValueType[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = GetRandomValues(Count)
                .Select(value => new FatValueType(value))
                .ToArray();
    }
}
