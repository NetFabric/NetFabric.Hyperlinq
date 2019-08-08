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
    public class AllBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public bool Linq_Range() => 
            System.Linq.Enumerable.All(linqRange, _ => true);

        [BenchmarkCategory("LinkedList")]
        [Benchmark(Baseline = true)]
        public bool Linq_LinkedList() => 
            System.Linq.Enumerable.All(linkedList, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() => 
            System.Linq.Enumerable.All(array, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public bool Linq_List() => 
            System.Linq.Enumerable.All(list, _ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.All(enumerableReference, _ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() => 
            System.Linq.Enumerable.All(enumerableValue, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_Array() =>
            array.AllF(_ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool LinqFaster_List() =>
            list.AllF(_ => true);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public bool Hyperlinq_Range() =>
            hyperlinqRange.All(_ => true);

        [BenchmarkCategory("LinkedList")]
        [Benchmark]
        public bool Hyperlinq_LinkedList() => 
            linkedList.All(_ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() =>
            array.All(_ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool Hyperlinq_List() => 
            list.All(_ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() => 
            enumerableReference.AsValueEnumerable().All(_ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() => 
            enumerableValue.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>().All(_ => true);
    }
}
