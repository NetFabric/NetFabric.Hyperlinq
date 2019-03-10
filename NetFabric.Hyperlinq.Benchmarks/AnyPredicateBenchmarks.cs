using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using JM.LinqFaster.Parallel;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class AnyPredicateBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() => 
            System.Linq.Enumerable.Any(array, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public bool Linq_List() => 
            System.Linq.Enumerable.Any(list, _ => true);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public bool Linq_Range() => 
            System.Linq.Enumerable.Any(linqRange, _ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.Any(enumerableReference, _ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Linq_Enumerable_Value() => 
            System.Linq.Enumerable.Any(enumerableValue, _ => true);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.Any(arrayAsEnumerable, _ => true);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.Any(arrayAsReadOnlyCollection, _ => true);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.Any(arrayAsReadOnlyList, _ => true);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.Any(listAsEnumerable, _ => true);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.Any(listAsReadOnlyCollection, _ => true);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.Any(listAsReadOnlyList, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_Array() =>
            array.AnyF(_ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool LinqFaster_List() =>
            list.AnyF(_ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() => 
            array.Any(_ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool Hyperlinq_List() => 
            list.Any(_ => true);

        [BenchmarkCategory("Range")]
        [Benchmark]

        public bool Hyperlinq_Range() =>
            hyperlinqRange.Any(_ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() => 
            enumerableReference.Any(_ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() => 
            enumerableValue.Any<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(_ => true);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public bool Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.Any(_ => true);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public bool Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.Any(_ => true);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public bool Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.Any(_ => true);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public bool Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.Any(_ => true);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public bool Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.Any(_ => true);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public bool Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.Any(_ => true);
    }
}
