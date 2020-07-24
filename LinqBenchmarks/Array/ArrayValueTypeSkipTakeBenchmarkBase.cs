using BenchmarkDotNet.Attributes;
using System.Linq;

namespace LinqBenchmarks
{
    public class ValueTypeArraySkipTakeBenchmarkBase: SkipTakeBenchmarkBase
    {
        protected FatValueType[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = System.Linq.Enumerable
                .Range(0, Skip + Count)
                .Select(value => new FatValueType(value))
                .ToArray();
    }
}
