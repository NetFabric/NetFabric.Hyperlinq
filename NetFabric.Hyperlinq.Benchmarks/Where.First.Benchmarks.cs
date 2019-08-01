using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereFirstBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range()
            => System.Linq.Enumerable.First(System.Linq.Enumerable.Where(linqRange, _ => true));

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue()
            => System.Linq.Enumerable.First(System.Linq.Enumerable.Where(queue, _ => true));

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => System.Linq.Enumerable.First(System.Linq.Enumerable.Where(array, _ => true));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List()
            => System.Linq.Enumerable.First(System.Linq.Enumerable.Where(list, _ => true));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
            => System.Linq.Enumerable.First(System.Linq.Enumerable.Where(enumerableReference, _ => true));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => System.Linq.Enumerable.First(System.Linq.Enumerable.Where(enumerableValue, _ => true));

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range()
            => hyperlinqRange.Where(_ => true).First();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue()
            => queue.Where(_ => true).First();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
            => array.Where(_ => true).First();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List()
            => list.Where(_ => true).First();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference.AsValueEnumerable().Where(_ => true).First();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>().Where(_ => true).First();
    }
}
