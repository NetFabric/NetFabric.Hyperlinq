using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SelectCountBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(linqRange, item => item));

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(queue, item => item));

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(array, item => item));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(list, item => item));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(enumerableReference, item => item));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()       
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(enumerableValue, item => item));

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
            => hyperlinqRange.Select(item => item).Count();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue() 
            => queue.Select(item => item).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
            => array.Select(item => item).Count();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
            => list.Select(item => item).Count();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference.Select(item => item).Count();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()        
            => enumerableValue.Select(item => item).Count();
    }
}
