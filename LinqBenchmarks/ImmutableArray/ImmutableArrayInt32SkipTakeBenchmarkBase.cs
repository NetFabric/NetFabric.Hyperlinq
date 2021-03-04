using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace LinqBenchmarks
{
    public class ImmutableArrayInt32SkipTakeBenchmarkBase : SkipTakeBenchmarkBase
    {
        protected ImmutableArray<int> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = GetRandomValues(Skip + Count).ToImmutableArray();
    }
}
