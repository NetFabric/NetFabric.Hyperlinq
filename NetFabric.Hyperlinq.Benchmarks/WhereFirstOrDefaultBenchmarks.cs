using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereFirstOrDefaultBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_FirstOrDefault()
            => System.Linq.Enumerable.FirstOrDefault(System.Linq.Enumerable.Where(array, _ => true));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List_FirstOrDefault()
            => System.Linq.Enumerable.FirstOrDefault(System.Linq.Enumerable.Where(list, _ => true));

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range_FirstOrDefault()
            => System.Linq.Enumerable.FirstOrDefault(System.Linq.Enumerable.Where(linqRange, _ => true));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_FirstOrDefault()
            => array.Where(_ => true).FirstOrDefault();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int? Hyperlinq_Array_FirstOrNull()
            => array.Where(_ => true).FirstOrNull();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List_FirstOrDefault()
            => list.Where(_ => true).FirstOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int? Hyperlinq_List_FirstOrNull()
            => list.Where(_ => true).FirstOrNull();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_FirstOrDefault()
            => hyperlinqRange.Where(_ => true).FirstOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int? Hyperlinq_Range_FirstOrNull()
            => hyperlinqRange.Where(_ => true).FirstOrNull();
    }
}
