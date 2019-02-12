using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class SelectToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array() 
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(array, item => item));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List() 
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(list, item => item));

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Range() 
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(linqRange, item => item));

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable() 
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(enumerable, item => item));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array() 
            => array.Select(item => item).ToList();

        [BenchmarkCategory("List")]
        [Benchmark]
        public List<int> Hyperlinq_List() 
            => list.Select(item => item).ToList();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public List<int> Hyperlinq_Range() 
            => hyperlinqRange.Select(item => item).ToList();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable() 
            => enumerable.Select(item => item).ToList();
    }
}
