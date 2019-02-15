using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class WhereToArrayBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array()
            => System.Linq.Enumerable.Where(array, _ => true).ToArray();

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List()
            => System.Linq.Enumerable.Where(list, _ => true).ToArray();

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Range()
            => System.Linq.Enumerable.Where(linqRange, _ => true).ToArray();

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference()
            => System.Linq.Enumerable.Where(enumerableReference, _ => true).ToArray();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int[] Linq_Enumerable_Value()
            => System.Linq.Enumerable.Where(enumerableValue, _ => true).ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array()
            => array.Where(_ => true).ToArray();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int[] Hyperlinq_List()
            => list.Where(_ => true).ToArray();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int[] Hyperlinq_Range()
            => hyperlinqRange.Where(_ => true).ToArray();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference()
            => enumerableReference.Where(_ => true).ToArray();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value()
            => enumerableValue.Where<MyEnumerable.Enumerable, MyEnumerable.Enumerable.Enumerator, int>(_ => true).ToArray();
    }
}
