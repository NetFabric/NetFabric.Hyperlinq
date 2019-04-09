using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class FirstBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() =>
            System.Linq.Enumerable.First(linqRange);

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue() => 
            System.Linq.Enumerable.First(queue);

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.First(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() =>
            System.Linq.Enumerable.First(list);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.First(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() => 
            System.Linq.Enumerable.First(enumerableValue);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_Array() =>
            array.FirstF(_ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int LinqFaster_List() =>
            list.FirstF(_ => true);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() =>
            hyperlinqRange.First();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue() => 
            queue.First();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() =>
            array.First();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() =>
            list.First();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() => 
            enumerableReference.First();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() => 
            enumerableValue.First<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();
    }
}
