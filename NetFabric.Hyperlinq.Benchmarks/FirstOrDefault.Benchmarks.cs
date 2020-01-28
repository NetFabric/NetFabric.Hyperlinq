using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;

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

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.FirstOrDefault(enumerableValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value() =>
            System.Linq.Enumerable.FirstOrDefault(collectionValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value() =>
            System.Linq.Enumerable.FirstOrDefault(listValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.FirstOrDefault(enumerableReference);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference() =>
            System.Linq.Enumerable.FirstOrDefault(collectionReference);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference() =>
            System.Linq.Enumerable.FirstOrDefault(listReference);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_Array() =>
            array.FirstOrDefaultF();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() =>
            array.FirstOrDefault();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .FirstOrDefault();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .FirstOrDefault();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .FirstOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .FirstOrDefault();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .FirstOrDefault();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .FirstOrDefault();
    }
}
