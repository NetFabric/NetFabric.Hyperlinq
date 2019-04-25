using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereToArrayBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Range()
            => System.Linq.Enumerable.Where(linqRange, (_, __) => true).ToArray();

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Queue()
            => System.Linq.Enumerable.Where(queue, (_, __) => true).ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array()
            => System.Linq.Enumerable.Where(array, (_, __) => true).ToArray();

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List()
            => System.Linq.Enumerable.Where(list, (_, __) => true).ToArray();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public long[] Linq_Enumerable_Reference() 
            => System.Linq.Enumerable.Where(enumerableReference, (_, __) => true).ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public long[] Linq_Enumerable_Value()
            => System.Linq.Enumerable.Where(enumerableValue, (_, __) => true).ToArray();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public long[] Hyperlinq_Range()
            => hyperlinqRange.Where((_, __) => true).ToArray();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int[] Hyperlinq_Queue()
            => queue.Where((_, __) => true).ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array()
            => array.Where((_, __) => true).ToArray();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int[] Hyperlinq_List()
            => list.Where((_, __) => true).ToArray();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public long[] Hyperlinq_Enumerable_Reference()
            => enumerableReference.Where((_, __) => true).ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public long[] Hyperlinq_Enumerable_Value()
            => enumerableValue.Where((_, __) => true).ToArray();
    }
}
