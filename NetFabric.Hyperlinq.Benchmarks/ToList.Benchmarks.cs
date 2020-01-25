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
    public class ToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array() =>
            System.Linq.Enumerable.ToList(array);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToList(enumerableValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Value() =>
            System.Linq.Enumerable.ToList(collectionValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Value() =>
            System.Linq.Enumerable.ToList(listValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToList(enumerableReference);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Reference() =>
            System.Linq.Enumerable.ToList(collectionReference);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Reference() =>
            System.Linq.Enumerable.ToList(listReference);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array() =>
            array.ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Span() =>
            array.AsSpan().ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Memory() =>
            array.AsMemory().ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<TestList.Enumerable, int>(listValue)
            .ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .ToList();
    }
}
