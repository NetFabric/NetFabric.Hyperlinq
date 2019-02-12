using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class WhereSelectCountBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(array, _ => true), item => item));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(list, _ => true), item => item));

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(linqRange, _ => true), item => item));

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(enumerable, _ => true), item => item));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
            => array.Where(_ => true).Select(item => item).Count();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
            => list.Where(_ => true).Select(item => item).Count();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
            => hyperlinqRange.Where(_ => true).Select(item => item).Count();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable() 
            => enumerable.Where(_ => true).Select(item => item).Count();
    }
}
