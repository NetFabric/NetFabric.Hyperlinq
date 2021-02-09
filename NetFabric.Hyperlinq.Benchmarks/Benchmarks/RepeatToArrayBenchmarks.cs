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
    public class RepeatToArrayBenchmarks : CountBenchmarksBase
    {
        [BenchmarkCategory("Repeat")]
        [Benchmark(Baseline = true)]
        public int[] Linq() 
            => Enumerable.Repeat(0, Count).ToArray();

        [BenchmarkCategory("Repeat_Async")]
        [Benchmark(Baseline = true)]
        public ValueTask<int[]> Linq_Async()
            => AsyncEnumerable.Repeat(0, Count).ToArrayAsync();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int[] StructLinq()
            => StructEnumerable.Repeat(0, (uint)Count).ToArray();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int[] LinqFaster_SIMD()
            => LinqFasterSIMD.RepeatS(0, Count);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int[] Hyperlinq() 
            => ValueEnumerable.Repeat(0, Count).ToArray();

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int[] Hyperlinq_SIMD()
            => ValueEnumerable.Repeat(0, Count).ToArrayVector();

        [BenchmarkCategory("Repeat_Async")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_Async()
            => AsyncValueEnumerable.Repeat(0, Count).ToArrayAsync();

    }
}