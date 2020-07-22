using BenchmarkDotNet.Attributes;
using System.Linq;

namespace LinqBenchmarks
{
    public class RangeBenchmarkBase : BenchmarkBase
    {
        [Params(0)]
        public int Start { get; set; }
    }
}
