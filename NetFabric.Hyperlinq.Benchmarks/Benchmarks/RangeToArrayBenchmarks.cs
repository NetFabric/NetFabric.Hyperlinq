using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster.SIMD;
using StructLinq;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class RangeToArrayBenchmarks : CountBenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int[] Linq() 
            => Enumerable.Range(0, Count).ToArray();

        [BenchmarkCategory("Range_Async")]
        [Benchmark(Baseline = true)]
        public ValueTask<int[]> Linq_Async()
            => AsyncEnumerable.Range(0, Count).ToArrayAsync();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int[] StructLinq()
            => StructEnumerable.Range(0, Count).ToArray();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int[] LinqFaster_SIMD()
            => LinqFasterSIMD.RangeS(0, Count);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int[] Hyperlinq() 
            => ValueEnumerable.Range(0, Count).ToArray();

        [BenchmarkCategory("Range_Async")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_Async()
            => AsyncValueEnumerable.Range(0, Count).ToArrayAsync();

    }
}