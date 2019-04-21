using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Range()
            => System.Linq.Enumerable.Where(linqRange, (_, __) => true).ToList();

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Queue()
            => System.Linq.Enumerable.Where(queue, (_, __) => true).ToList();

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array()
            => System.Linq.Enumerable.Where(array, (_, __) => true).ToList();

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List()
            => System.Linq.Enumerable.Where(list, (_, __) => true).ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference() 
            => System.Linq.Enumerable.Where(enumerableReference, (_, __) => true).ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value()
            => System.Linq.Enumerable.Where(enumerableValue, (_, __) => true).ToList();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public List<int> Hyperlinq_Range()
            => hyperlinqRange.Where((_, __) => true).ToList();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public List<int> Hyperlinq_Queue()
            => queue.Where((_, __) => true).ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array()
            => array.Where((_, __) => true).ToList();

        [BenchmarkCategory("List")]
        [Benchmark]
        public List<int> Hyperlinq_List()
            => list.Where((_, __) => true).ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference()
            => enumerableReference.Where((_, __) => true).ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value()
            => enumerableValue.Where((_, __) => true).ToList();
    }
}
