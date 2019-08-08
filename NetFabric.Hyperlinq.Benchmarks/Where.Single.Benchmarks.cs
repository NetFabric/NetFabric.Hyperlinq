using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereSingleBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range()
            => System.Linq.Enumerable.Single(System.Linq.Enumerable.Where(linqRange, _ => true));

        [BenchmarkCategory("LinkedList")]
        [Benchmark(Baseline = true)]
        public int Linq_LinkedList()
            => System.Linq.Enumerable.Single(System.Linq.Enumerable.Where(linkedList, _ => true));

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => System.Linq.Enumerable.Single(System.Linq.Enumerable.Where(array, _ => true));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List()
            => System.Linq.Enumerable.Single(System.Linq.Enumerable.Where(list, _ => true));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
            => System.Linq.Enumerable.Single(System.Linq.Enumerable.Where(enumerableReference, _ => true));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => System.Linq.Enumerable.Single(System.Linq.Enumerable.Where(enumerableValue, _ => true));

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range()
            => hyperlinqRange.Where(_ => true).Single();

        [BenchmarkCategory("LinkedList")]
        [Benchmark]
        public int Hyperlinq_LinkedList()
            => linkedList.Where(_ => true).Single();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
            => array.Where(_ => true).Single();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List()
            => list.Where(_ => true).Single();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference.AsValueEnumerable().Where(_ => true).Single();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>().Where(_ => true).Single();
    }
}
