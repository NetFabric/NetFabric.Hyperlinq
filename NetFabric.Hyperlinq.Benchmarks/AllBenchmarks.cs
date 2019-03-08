using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using JM.LinqFaster.Parallel;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class AllBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() => 
            System.Linq.Enumerable.All(array, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public bool Linq_List() => 
            System.Linq.Enumerable.All(list, _ => true);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public bool Linq_Range() => 
            System.Linq.Enumerable.All(linqRange, _ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.All(enumerableReference, _ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() => 
            System.Linq.Enumerable.All(enumerableValue, _ => true);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.All(arrayAsEnumerable, _ => true);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.All(arrayAsReadOnlyCollection, _ => true);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.All(arrayAsReadOnlyList, _ => true);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.All(listAsEnumerable, _ => true);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.All(listAsReadOnlyCollection, _ => true);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.All(listAsReadOnlyList, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() =>
            array.All(_ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool Hyperlinq_List() => 
            list.All(_ => true);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public bool Hyperlinq_Range() =>
            hyperlinqRange.All(_ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() => 
            enumerableReference.All(_ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() => 
            enumerableValue.All<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(_ => true);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public bool Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.All(_ => true);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public bool Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.All(_ => true);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public bool Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.All(_ => true);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public bool Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.All(_ => true);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public bool Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.All(_ => true);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public bool Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.All(_ => true);
    }
}
