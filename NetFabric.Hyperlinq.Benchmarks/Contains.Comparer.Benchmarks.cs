using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ContainsComparerBenchmarks : BenchmarksBase, IEqualityComparer<int>
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() =>
            Enumerable.Contains(array, Count - 1, this);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() =>
            Enumerable.Contains(enumerableValue, Count - 1, this);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value() =>
            Enumerable.Contains(collectionValue, Count - 1, this);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value() =>
            Enumerable.Contains(listValue, Count - 1, this);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() =>
            Enumerable.Contains(enumerableReference, Count - 1, this);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference() =>
            Enumerable.Contains(collectionReference, Count - 1, this);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference() =>
            Enumerable.Contains(listReference, Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_ConstainsF() =>
            LinqFaster.ContainsF(array, Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() =>
            ArrayExtensions.Contains(array, Count - 1, this);

#if SPAN_SUPPORTED
        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span() =>
            ArrayExtensions.Contains(array.AsSpan(), Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory() =>
            ArrayExtensions.Contains(memory, Count - 1, this);
#endif

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() =>
            EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Contains(Count - 1, this);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value() =>
            ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Contains(Count - 1, this);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value() =>
            ReadOnlyListExtensions.Contains(listValue, Count - 1, this);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Contains(Count - 1, this);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Contains(Count - 1, this);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool Hyperlinq_List_Reference() =>
            ReadOnlyListExtensions.Contains(listReference, Count - 1, this);

        public bool Equals(int x, int y) 
            => EqualityComparer<int>.Default.Equals(x, y);

        public int GetHashCode(int obj)
            => EqualityComparer<int>.Default.GetHashCode(obj);
    }
}
