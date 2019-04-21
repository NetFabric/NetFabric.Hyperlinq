using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereSelectCountBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(linqRange, _ => true), item => item));

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(queue, _ => true), item => item));

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(array, _ => true), item => item));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(list, _ => true), item => item));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(enumerableReference, _ => true), item => item));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(enumerableValue, _ => true), item => item));

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
            => hyperlinqRange.Where((_, __) => true).Select((item, _) => item).Count();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue() 
            => queue.Where((_, __) => true).Select((item, _) => item).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
            => array.Where((_, __) => true).Select((item, _) => item).Count();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
            => list.Where((_, __) => true).Select((item, _) => item).Count();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference.Where((_, __) => true).Select((item, _) => item).Count();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => enumerableValue.Where((_, __) => true).Select((item, _) => item).Count();
    }
}
