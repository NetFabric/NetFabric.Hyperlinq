using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class WhereToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array()
            => System.Linq.Enumerable.Where(array, _ => true).ToList();

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List()
            => System.Linq.Enumerable.Where(list, _ => true).ToList();

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Range()
            => System.Linq.Enumerable.Where(linqRange, _ => true).ToList();

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable()
            => System.Linq.Enumerable.Where(enumerable, _ => true).ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array()
            => array.Where(_ => true).ToList();

        [BenchmarkCategory("List")]
        [Benchmark]
        public List<int> Hyperlinq_List()
            => list.Where(_ => true).ToList();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public List<int> Hyperlinq_Range()
            => hyperlinqRange.Where(_ => true).ToList();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable()
            => enumerable.Where(_ => true).ToList();
    }
}
