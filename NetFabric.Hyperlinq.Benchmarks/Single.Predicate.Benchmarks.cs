using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SinglePredicateBenchmarks : BenchmarksBase
    {
        [Params(5_000)]
        public int ItemValue { get; set; }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.Single(array, item => item == ItemValue);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.Single(enumerableValue, item => item == ItemValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value() =>
            System.Linq.Enumerable.Single(collectionValue, item => item == ItemValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value() =>
            System.Linq.Enumerable.Single(listValue, item => item == ItemValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.Single(enumerableReference, item => item == ItemValue);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference() =>
            System.Linq.Enumerable.Single(collectionReference, item => item == ItemValue);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference() =>
            System.Linq.Enumerable.Single(listReference, item => item == ItemValue);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_Array() =>
            array.SingleF(item => item == ItemValue);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() =>
            array.Single(item => item == ItemValue);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Single(item => item == ItemValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Single(item => item == ItemValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .Single(item => item == ItemValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Single(item => item == ItemValue);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Single(item => item == ItemValue);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .Single(item => item == ItemValue);
    }
}
