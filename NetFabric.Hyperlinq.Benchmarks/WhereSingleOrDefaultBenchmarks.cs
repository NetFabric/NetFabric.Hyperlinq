using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereSingleOrDefaultBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_SingleOrDefault()
            => System.Linq.Enumerable.SingleOrDefault(System.Linq.Enumerable.Where(array, value => value == 0));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List_SingleOrDefault()
            => System.Linq.Enumerable.SingleOrDefault(System.Linq.Enumerable.Where(list, value => value == 0));

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range_SingleOrDefault()
            => System.Linq.Enumerable.SingleOrDefault(System.Linq.Enumerable.Where(linqRange, value => value == 0));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_SingleOrDefault()
            => array.Where(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int? Hyperlinq_Array_SingleOrNull()
            => array.Where(value => value == 0).SingleOrNull();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List_SingleOrDefault()
            => list.Where(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int? Hyperlinq_List_SingleOrNull()
            => list.Where(value => value == 0).SingleOrNull();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_SingleOrDefault()
            => hyperlinqRange.Where(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int? Hyperlinq_Range_SingleOrNull()
            => hyperlinqRange.Where(value => value == 0).SingleOrNull();
    }
}
