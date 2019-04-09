using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Range() =>
            System.Linq.Enumerable.ToList(linqRange);

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Queue() =>
            System.Linq.Enumerable.ToList(queue);

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array() =>
            System.Linq.Enumerable.ToList(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List() =>
            System.Linq.Enumerable.ToList(list);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.ToList(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value() => 
            System.Linq.Enumerable.ToList(enumerableValue);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public List<int> Hyperlinq_Range() =>
            hyperlinqRange.ToList();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public List<int> Hyperlinq_Queue() =>
            queue.ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array() =>
            array.ToList();

        [BenchmarkCategory("List")]
        [Benchmark]
        public List<int> Hyperlinq_List() =>
            list.ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference() => 
            enumerableReference.ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value() => 
            enumerableValue.ToList();
    }
}
