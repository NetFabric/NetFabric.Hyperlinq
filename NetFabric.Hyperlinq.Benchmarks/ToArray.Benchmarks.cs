using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToArrayBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() =>
            System.Linq.Enumerable.ToArray(array);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToArray(enumerableValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Value() =>
            System.Linq.Enumerable.ToArray(collectionValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Value() =>
            System.Linq.Enumerable.ToArray(listValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToArray(enumerableReference);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Reference() =>
            System.Linq.Enumerable.ToArray(collectionReference);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Reference() =>
            System.Linq.Enumerable.ToArray(listReference);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array() =>
            array.ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator())
            .ToArray();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .ToArray();
    }
}
