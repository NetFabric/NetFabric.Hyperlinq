using BenchmarkDotNet.Attributes;

namespace LinqBenchmarks
{
    public class RangeBenchmarkBase : BenchmarkBase
    {
        [Params(0)]
        public int Start { get; set; }
    }
}
