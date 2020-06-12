using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SelectToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(array, item => item));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(enumerableValue, item => item));

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Value() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(collectionValue, item => item));

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Value() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(listValue, item => item));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(enumerableReference, item => item));

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Reference() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(collectionReference, item => item));

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Reference() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(listReference, item => item));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array() =>
            array.Select(item => item).ToList();

#if SPAN_SUPPORTED
        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Span() =>
            array.AsSpan().Select(item => item).ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Memory() =>
            memory.Select(item => item).ToList();
#endif

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value() =>
            EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Select(item => item).ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Value() =>
            ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Select(item => item).ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> Hyperlinq_List_Value() =>
            ReadOnlyListExtensions.AsValueEnumerable<int>(listValue)
            .Select(item => item).ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Select(item => item).ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Select(item => item).ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .Select(item => item).ToList();
    }
}
