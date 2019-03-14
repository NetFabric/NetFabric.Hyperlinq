using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array() =>
            System.Linq.Enumerable.ToList(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List() =>
            System.Linq.Enumerable.ToList(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Range() =>
            System.Linq.Enumerable.ToList(linqRange);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToList(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToList(enumerableValue);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.ToList(arrayAsEnumerable);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.ToList(arrayAsReadOnlyCollection);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.ToList(arrayAsReadOnlyList);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.ToList(listAsEnumerable);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.ToList(listAsReadOnlyCollection);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.ToList(listAsReadOnlyList);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array() =>
            array.ToList();

        [BenchmarkCategory("List")]
        [Benchmark]
        public List<int> Hyperlinq_List() =>
            list.ToList();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public List<int> Hyperlinq_Range() =>
            hyperlinqRange.ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference() =>
            enumerableReference.ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value() =>
            enumerableValue.ToList<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public List<int> Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.ToList();

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public List<int> Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.ToList();

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public List<int> Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.ToList();

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public List<int> Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.ToList();

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public List<int> Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.ToList();

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public List<int> Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.ToList();
    }
}
