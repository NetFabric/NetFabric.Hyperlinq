using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class CountPredicateBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() => 
            System.Linq.Enumerable.Count(linqRange, _ => true);

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue() => 
            System.Linq.Enumerable.Count(queue, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() => 
            System.Linq.Enumerable.Count(array, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() => 
            System.Linq.Enumerable.Count(list, _ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.Count(enumerableReference, _ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() => 
            System.Linq.Enumerable.Count(enumerableValue, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_Array() =>
            array.CountF(_ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int LinqFaster_List() =>
            list.CountF(_ => true);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public long Hyperlinq_Range() =>
            hyperlinqRange.Count((_, __) => true);

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue() => 
            queue.Count((_, __) => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() => 
            array.Count((_, __) => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() => 
            list.Count((_, __) => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public long Hyperlinq_Enumerable_Reference() => 
            enumerableReference.Count((_, __) => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public long Hyperlinq_Enumerable_Value() => 
            enumerableValue.Count<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, long>((_, __) => true);
    }
}
