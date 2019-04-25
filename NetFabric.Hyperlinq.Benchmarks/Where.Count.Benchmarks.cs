using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereCountBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Where(linqRange, (_, __) => true));

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Where(queue, (_, __) => true));

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Where(array, (_, __) => true));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Where(list, (_, __) => true));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Where(enumerableReference, (_, __) => true));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Where(enumerableValue, (_, __) => true));

        [BenchmarkCategory("Range")]
        [Benchmark]
        public long Hyperlinq_Range()
            => hyperlinqRange.Where((_, __) => true).Count();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public long Hyperlinq_Queue()
            => queue.Where((_, __) => true).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public long Hyperlinq_Array()
            => array.Where((_, __) => true).Count();

        [BenchmarkCategory("List")]
        [Benchmark]
        public long Hyperlinq_List()
            => list.Where((_, __) => true).Count();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public long Hyperlinq_Enumerable_Reference()
            => enumerableReference.Where((_, __) => true).Count();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public long Hyperlinq_Enumerable_Value()
            => enumerableValue.Where((_, __) => true).Count();
    }
}
