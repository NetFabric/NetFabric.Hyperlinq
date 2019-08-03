using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

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
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(linqRange, _ => true));

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Queue()
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(queue, _ => true));

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array()
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(array, _ => true));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List()
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(list, _ => true));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference()
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(enumerableReference, _ => true));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value()
            => System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(enumerableValue, _ => true));

        [BenchmarkCategory("Range")]
        [Benchmark]
        public List<int> Hyperlinq_Range()
            => hyperlinqRange.Where(_ => true).ToList();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public List<int> Hyperlinq_Queue()
            => queue.Where(_ => true).ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array()
            => array.Where(_ => true).ToList();

        [BenchmarkCategory("List")]
        [Benchmark]
        public List<int> Hyperlinq_List()
            => list.Where(_ => true).ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference()
            => enumerableReference.AsValueEnumerable().Where(_ => true).ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>().Where(_ => true).ToList();
    }
}
