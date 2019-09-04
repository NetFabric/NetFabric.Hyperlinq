using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class LongCountPredicateBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public long Linq_Array() =>
            System.Linq.Enumerable.LongCount(array, _ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public long Linq_Enumerable_Value() =>
            System.Linq.Enumerable.LongCount(enumerableValue, _ => true);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public long Linq_Collection_Value() =>
            System.Linq.Enumerable.LongCount(collectionValue, _ => true);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public long Linq_List_Value() =>
            System.Linq.Enumerable.LongCount(listValue, _ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public long Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.LongCount(enumerableReference, _ => true);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public long Linq_Collection_Reference() =>
            System.Linq.Enumerable.LongCount(collectionReference, _ => true);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public long Linq_List_Reference() =>
            System.Linq.Enumerable.LongCount(listReference, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public long Hyperlinq_Array() =>
            array.LongCount(_ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public long Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .LongCount(_ => true);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public long Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .LongCount(_ => true);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public long Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator())
            .LongCount(_ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public long Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .LongCount(_ => true);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public long Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .LongCount(_ => true);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public long Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .LongCount(_ => true);
    }
}
