using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereToArrayBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(array, item => (item & 0x01) == 0));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(enumerableValue, item => (item & 0x01) == 0));

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Value() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(collectionValue, item => (item & 0x01) == 0));

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Value() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(listValue, item => (item & 0x01) == 0));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(enumerableReference, item => (item & 0x01) == 0));

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Reference() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(collectionReference, item => (item & 0x01) == 0));

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Reference() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(listReference, item => (item & 0x01) == 0));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array() =>
            array.Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Span() =>
            array.AsSpan().Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Memory() =>
            array.AsMemory().Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Where(item => (item & 0x01) == 0).ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .Where(item => (item & 0x01) == 0).ToArray();
    }
}
