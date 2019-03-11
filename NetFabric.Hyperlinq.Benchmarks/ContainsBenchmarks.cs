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
    public class ContainsBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() => 
            System.Linq.Enumerable.Contains(array, Count - 1);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public bool Linq_List() => 
            System.Linq.Enumerable.Contains(list, Count - 1);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public bool Linq_Range() => 
            System.Linq.Enumerable.Contains(linqRange, Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.Contains(enumerableReference, Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Linq_Enumerable_Value() => 
            System.Linq.Enumerable.Contains(enumerableValue, Count - 1);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.Contains(arrayAsEnumerable, Count - 1);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.Contains(arrayAsReadOnlyCollection, Count - 1);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.Contains(arrayAsReadOnlyList, Count - 1);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.Contains(listAsEnumerable, Count - 1);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.Contains(listAsReadOnlyCollection, Count - 1);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.Contains(listAsReadOnlyList, Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_Array() =>
            array.ContainsF(Count - 1);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool LinqFaster_List() =>
            list.ContainsF(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() => 
            array.Contains(Count - 1);

        [BenchmarkCategory("List")]
        [Benchmark]
        public bool Hyperlinq_List() => 
            list.Contains(Count - 1);

        [BenchmarkCategory("Range")]
        [Benchmark]

        public bool Hyperlinq_Range() =>
            hyperlinqRange.Contains(Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() => 
            enumerableReference.Contains(Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() => 
            enumerableValue.Contains<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(Count - 1);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public bool Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.Contains(Count - 1);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public bool Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.Contains(Count - 1);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public bool Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.Contains(Count - 1);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public bool Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.Contains(Count - 1);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public bool Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.Contains(Count - 1);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public bool Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.Contains(Count - 1);
    }
}
