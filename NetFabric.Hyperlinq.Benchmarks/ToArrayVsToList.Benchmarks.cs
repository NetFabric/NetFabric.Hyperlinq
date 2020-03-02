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
    public class ToArrayVsToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array_ToArray() =>
            System.Linq.Enumerable.ToArray(array);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Linq_Array_ToList() =>
            System.Linq.Enumerable.ToList(array);

        [BenchmarkCategory("Enumerable_ValueEnumerator")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_ValueEnumerator_ToArray() =>
            System.Linq.Enumerable.ToArray(enumerableValue);

        [BenchmarkCategory("Enumerable_ValueEnumerator")]
        [Benchmark]
        public List<int> Linq_Enumerable_ValueEnumerator_ToList() =>
            System.Linq.Enumerable.ToList(enumerableValue);

        [BenchmarkCategory("Collection_ValueEnumerator")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_ValueEnumerator_ToArray() =>
            System.Linq.Enumerable.ToArray(collectionValue);

        [BenchmarkCategory("Collection_ValueEnumerator")]
        [Benchmark]
        public List<int> Linq_Collection_ValueEnumerator_ToList() =>
            System.Linq.Enumerable.ToList(collectionValue);

        [BenchmarkCategory("List_ValueEnumerator")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_ValueEnumerator_ToArray() =>
            System.Linq.Enumerable.ToArray(listValue);

        [BenchmarkCategory("List_ValueEnumerator")]
        [Benchmark]
        public List<int> Linq_List_ValueEnumerator_ToList() =>
            System.Linq.Enumerable.ToList(listValue);

        [BenchmarkCategory("Enumerable_ReferenceEnumerator")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_ReferenceEnumerator_ToArray() =>
            System.Linq.Enumerable.ToArray(enumerableReference);

        [BenchmarkCategory("Enumerable_ReferenceEnumerator")]
        [Benchmark]
        public List<int> Linq_EnumerableEnumerator_Reference_ToList() =>
            System.Linq.Enumerable.ToList(enumerableReference);

        [BenchmarkCategory("Collection_ReferenceEnumerator")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_ReferenceEnumerator_ToArray() =>
            System.Linq.Enumerable.ToArray(collectionReference);

        [BenchmarkCategory("Collection_ReferenceEnumerator")]
        [Benchmark]
        public List<int> Linq_Collection_ReferenceEnumerator_ToList() =>
            System.Linq.Enumerable.ToList(collectionReference);

        [BenchmarkCategory("List_ReferenceEnumerator")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_ReferenceEnumerator_ToArray() =>
            System.Linq.Enumerable.ToArray(listReference);

        [BenchmarkCategory("List_ReferenceEnumerator")]
        [Benchmark]
        public List<int> Linq_List_ReferenceEnumerator_ToList() =>
            System.Linq.Enumerable.ToList(listReference);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array_ToArray() =>
            array.AsSpan().ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array_ToList() =>
            array.AsSpan().ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Span_ToArray() =>
            array.AsSpan().ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Span_ToList() =>
            array.AsSpan().ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Memory_ToArray() =>
            memory.ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Memory_ToList() =>
            memory.ToList();

        [BenchmarkCategory("Enumerable_ValueEnumerator")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_ValueEnumerator_ToArray() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .ToArray();

        [BenchmarkCategory("Enumerable_ValueEnumerator")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_ValueEnumerator_ToList() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .ToList();

        [BenchmarkCategory("Collection_ValueEnumerator")]
        [Benchmark]
        public int[] Hyperlinq_Collection_ValueEnumerator_ToArray() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .ToArray();

        [BenchmarkCategory("Collection_ValueEnumerator")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_ValueEnumerator_ToList() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .ToList();

        [BenchmarkCategory("List_ValueEnumerator")]
        [Benchmark]
        public int[] Hyperlinq_List_ValueEnumerator_ToArray() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .ToArray();

        [BenchmarkCategory("List_ValueEnumerator")]
        [Benchmark]
        public List<int> Hyperlinq_List_ValueEnumerator_ToList() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .ToList();

        [BenchmarkCategory("Enumerable_ReferenceEnumerator")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_ReferenceEnumerator_ToArray() =>
            enumerableReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("Enumerable_ReferenceEnumerator")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_ReferenceEnumerator_ToList() =>
            enumerableReference
            .AsValueEnumerable()
            .ToList();

        [BenchmarkCategory("Collection_ReferenceEnumerator")]
        [Benchmark]
        public int[] Hyperlinq_Collection_ReferenceEnumerator_ToArray() =>
            collectionReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("Collection_ReferenceEnumerator")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_ReferenceEnumerator_ToList() =>
            collectionReference
            .AsValueEnumerable()
            .ToList();

        [BenchmarkCategory("List_ReferenceEnumerator")]
        [Benchmark]
        public int[] Hyperlinq_List_ReferenceEnumerator_ToArray() =>
            listReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("List_ReferenceEnumerator")]
        [Benchmark]
        public List<int> Hyperlinq_List_ReferenceEnumerator_ToList() =>
            listReference
            .AsValueEnumerable()
            .ToList();
    }
}
