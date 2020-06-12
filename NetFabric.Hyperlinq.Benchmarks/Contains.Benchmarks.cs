using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ContainsBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() =>
            System.Linq.Enumerable.Contains(array, Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() =>
            System.Linq.Enumerable.Contains(enumerableValue, Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value() =>
            System.Linq.Enumerable.Contains(collectionValue, Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value() =>
            System.Linq.Enumerable.Contains(listValue, Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.Contains(enumerableReference, Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference() =>
            System.Linq.Enumerable.Contains(collectionReference, Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference() =>
            System.Linq.Enumerable.Contains(listReference, Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_ConstainsF() =>
            array.ContainsF(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_ContainsS() =>
            array.ContainsS(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() =>
            array.Contains(Count - 1);

#if SPAN_SUPPORTED

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span() =>
            array.AsSpan().Contains(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory() =>
            memory.Contains(Count - 1);

#endif

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Contains(Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Contains(Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable(listValue)
            .Contains(Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Contains(Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Contains(Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .Contains(Count - 1);
    }
}
