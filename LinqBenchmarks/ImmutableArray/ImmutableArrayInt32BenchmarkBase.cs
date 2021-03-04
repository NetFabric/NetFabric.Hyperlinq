using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace LinqBenchmarks
{
    public class ImmutableArrayInt32BenchmarkBase : BenchmarkBase
    {
        protected ImmutableArray<int> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = GetRandomValues(Count).ToImmutableArray();
    }
}
