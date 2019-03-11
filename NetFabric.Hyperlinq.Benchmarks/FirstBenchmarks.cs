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
    public class FirstBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.First(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() =>
            System.Linq.Enumerable.First(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() =>
            System.Linq.Enumerable.First(linqRange);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.First(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.First(enumerableValue);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.First(arrayAsEnumerable);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.First(arrayAsReadOnlyCollection);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.First(arrayAsReadOnlyList);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.First(listAsEnumerable);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.First(listAsReadOnlyCollection);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.First(listAsReadOnlyList);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() =>
            array.First();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() =>
            list.First();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() =>
            hyperlinqRange.First();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() =>
            enumerableReference.First();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() =>
            enumerableValue.First<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public int Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.First();

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public int Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.First();

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public int Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.First();

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public int Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.First();

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public int Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.First();

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public int Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.First();
    }
}
