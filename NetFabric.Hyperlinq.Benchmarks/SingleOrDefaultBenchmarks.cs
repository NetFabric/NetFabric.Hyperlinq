using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SingleOrDefaultBenchmarks
    {
        int[] array;
        List<int> list;
        IEnumerable<int> linqRange;
        Enumerable.RangeEnumerable hyperlinqRange;
        IEnumerable<int> enumerableReference;
        TestEnumerable.Enumerable enumerableValue;
        protected IEnumerable<int> arrayAsEnumerable;
        protected IReadOnlyCollection<int> arrayAsReadOnlyCollection;
        protected IReadOnlyList<int> arrayAsReadOnlyList;
        protected IEnumerable<int> listAsEnumerable;
        protected IReadOnlyCollection<int> listAsReadOnlyCollection;
        protected IReadOnlyList<int> listAsReadOnlyList;

        [GlobalSetup]
        public void GlobalSetup()
        {
            linqRange = System.Linq.Enumerable.Range(0, 1);
            hyperlinqRange = Enumerable.Range(0, 1);
            array = hyperlinqRange.ToArray();
            list = hyperlinqRange.ToList();
            enumerableReference = TestEnumerable.ReferenceType(1);
            enumerableValue = TestEnumerable.ValueType(1);
            arrayAsEnumerable = array;
            arrayAsReadOnlyCollection = array;
            arrayAsReadOnlyList = array;
            listAsEnumerable = list;
            listAsReadOnlyCollection = list;
            listAsReadOnlyList = list;
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.SingleOrDefault(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() =>
            System.Linq.Enumerable.SingleOrDefault(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() =>
            System.Linq.Enumerable.SingleOrDefault(linqRange);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.SingleOrDefault(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.SingleOrDefault(enumerableValue);

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsEnumerable() =>
            System.Linq.Enumerable.SingleOrDefault(arrayAsEnumerable);

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsReadOnlyCollection() =>
            System.Linq.Enumerable.SingleOrDefault(arrayAsReadOnlyCollection);

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_AsReadOnlyList() =>
            System.Linq.Enumerable.SingleOrDefault(arrayAsReadOnlyList);

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsEnumerable() =>
            System.Linq.Enumerable.SingleOrDefault(listAsEnumerable);

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsReadOnlyCollection() =>
            System.Linq.Enumerable.SingleOrDefault(listAsReadOnlyCollection);

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark(Baseline = true)]
        public int Linq_List_AsReadOnlyList() =>
            System.Linq.Enumerable.SingleOrDefault(listAsReadOnlyList);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() =>
            array.SingleOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() =>
            list.SingleOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark]

        public int Hyperlinq_Range() =>
            hyperlinqRange.SingleOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() =>
            enumerableReference.SingleOrDefault();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() =>
            enumerableValue.SingleOrDefault<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

        [BenchmarkCategory("Array_As_IEnumerable")]
        [Benchmark]
        public int Hyperlinq_Array_AsEnumerable() =>
            arrayAsEnumerable.SingleOrDefault();

        [BenchmarkCategory("Array_As_IReadOnlyCollection")]
        [Benchmark]
        public int Hyperlinq_Array_AsReadOnlyCollection() =>
            arrayAsReadOnlyCollection.SingleOrDefault();

        [BenchmarkCategory("Array_As_IReadOnlyList")]
        [Benchmark]
        public int Hyperlinq_Array_AsReadOnlyList() =>
            arrayAsReadOnlyList.SingleOrDefault();

        [BenchmarkCategory("List_As_IEnumerable")]
        [Benchmark]
        public int Hyperlinq_List_AsEnumerable() =>
            listAsEnumerable.SingleOrDefault();

        [BenchmarkCategory("List_As_IReadOnlyCollection")]
        [Benchmark]
        public int Hyperlinq_List_AsReadOnlyCollection() =>
            listAsReadOnlyCollection.SingleOrDefault();

        [BenchmarkCategory("List_As_IReadOnlyList")]
        [Benchmark]
        public int Hyperlinq_List_AsReadOnlyList() =>
            listAsReadOnlyList.SingleOrDefault();
    }
}
