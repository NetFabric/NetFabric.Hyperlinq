using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class CountBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() => 
            System.Linq.Enumerable.Count(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() => 
            System.Linq.Enumerable.Count(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() => 
            System.Linq.Enumerable.Count(linqRange);

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.Count(enumerableReference);

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Linq_Enumerable_Value() => 
            System.Linq.Enumerable.Count(enumerableValue);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() => 
            array.Count();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() => 
            list.Count();

        [BenchmarkCategory("Range")]
        [Benchmark]

        public int Hyperlinq_Range() =>
            hyperlinqRange.Count();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() => 
            enumerableReference.Count();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() => 
            enumerableValue.Count<MyEnumerable.Enumerable, MyEnumerable.Enumerable.Enumerator, int>();
    }
}
