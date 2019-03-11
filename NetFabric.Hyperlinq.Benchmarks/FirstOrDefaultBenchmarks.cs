using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class FirstOrDefaultBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.FirstOrDefault(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() =>
            System.Linq.Enumerable.FirstOrDefault(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() =>
            System.Linq.Enumerable.FirstOrDefault(linqRange);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.FirstOrDefault(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.FirstOrDefault(enumerableValue);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.FirstOrDefault(arrayAsEnumerable);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.FirstOrDefault(arrayAsReadOnlyCollection);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.FirstOrDefault(arrayAsReadOnlyList);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.FirstOrDefault(listAsEnumerable);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.FirstOrDefault(listAsReadOnlyCollection);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.FirstOrDefault(listAsReadOnlyList);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() =>
            array.FirstOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() =>
            list.FirstOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() =>
            hyperlinqRange.FirstOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() =>
            enumerableReference.FirstOrDefault();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() =>
            enumerableValue.FirstOrDefault<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public int Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.FirstOrDefault();

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public int Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.FirstOrDefault();

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public int Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.FirstOrDefault();

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public int Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.FirstOrDefault();

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public int Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.FirstOrDefault();

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public int Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.FirstOrDefault();
    }
}
