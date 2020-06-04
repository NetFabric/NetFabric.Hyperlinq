using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SelectToArrayBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(array, item => item));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(enumerableValue, item => item));

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Value() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(collectionValue, item => item));

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Value() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(listValue, item => item));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(enumerableReference, item => item));

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Reference() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(collectionReference, item => item));

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Reference() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(listReference, item => item));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array() =>
            array.Select(item => item).ToArray();

#if SPAN_SUPPORTED
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Span() =>
            array.AsSpan().Select(item => item).ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Memory() =>
            memory.Select(item => item).ToArray();
#endif

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Select(item => item).ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Select(item => item).ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .Select(item => item).ToArray();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Select(item => item).ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Select(item => item).ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .Select(item => item).ToArray();
    }
}
