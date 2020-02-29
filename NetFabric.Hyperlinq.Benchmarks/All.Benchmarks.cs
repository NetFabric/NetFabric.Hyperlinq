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
    public class AllBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() =>
        System.Linq.Enumerable.All(array, item => (item & 0x01) == 0);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() =>
            System.Linq.Enumerable.All(enumerableValue, item => (item & 0x01) == 0);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value() =>
            System.Linq.Enumerable.All(collectionValue, item => (item & 0x01) == 0);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value() =>
            System.Linq.Enumerable.All(listValue, item => (item & 0x01) == 0);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.All(enumerableReference, item => (item & 0x01) == 0);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference() =>
            System.Linq.Enumerable.All(collectionReference, item => (item & 0x01) == 0);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference() =>
            System.Linq.Enumerable.All(listReference, item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_Array() =>
            array.AllF(item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() =>
            array.All(item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span() =>
            array.AsSpan().All(item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory() =>
            memory.All(item => (item & 0x01) == 0);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .All(item => (item & 0x01) == 0);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .All(item => (item & 0x01) == 0);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .All(item => (item & 0x01) == 0);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .All(item => (item & 0x01) == 0);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .All(item => (item & 0x01) == 0);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .All(item => (item & 0x01) == 0);
    }
}
