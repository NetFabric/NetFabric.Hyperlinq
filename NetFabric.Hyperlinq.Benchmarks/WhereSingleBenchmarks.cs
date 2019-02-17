using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class WhereSingleBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => System.Linq.Enumerable.Where(array, _ => true).Single();

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List()
            => System.Linq.Enumerable.Where(list, _ => true).Single();

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range()
            => System.Linq.Enumerable.Where(linqRange, _ => true).Single();

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
            => System.Linq.Enumerable.Where(enumerableReference, _ => true).Single();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Linq_Enumerable_Value()
            => System.Linq.Enumerable.Where(enumerableValue, _ => true).Single();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
            => array.Where(_ => true).Single();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List()
            => list.Where(_ => true).Single();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range()
            => hyperlinqRange.Where(_ => true).Single();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference.Where(_ => true).Single();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => enumerableValue.Where<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(_ => true).Single();
    }
}
