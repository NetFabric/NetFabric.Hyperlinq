using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using System;
using System.Collections.Generic;

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
            System.Linq.Enumerable.Contains(array, Count - 1, this);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() =>
            System.Linq.Enumerable.Contains(enumerableValue, Count - 1, this);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value() =>
            System.Linq.Enumerable.Contains(collectionValue, Count - 1, this);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value() =>
            System.Linq.Enumerable.Contains(listValue, Count - 1, this);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.Contains(enumerableReference, Count - 1, this);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference() =>
            System.Linq.Enumerable.Contains(collectionReference, Count - 1, this);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference() =>
            System.Linq.Enumerable.Contains(listReference, Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool LinqFaster_Array() =>
            array.ContainsF(Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() =>
            array.Contains(Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span() =>
            array.AsSpan().Contains(Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory() =>
            memory.Contains(Count - 1, this);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Contains(Count - 1, this);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Contains(Count - 1, this);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .Contains(Count - 1, this);

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
            listReference
            .AsValueEnumerable()
            .Contains(Count - 1, this);

        public bool Equals(int x, int y) 
            => x.Equals(y);

        public int GetHashCode(int obj)
            => obj.GetHashCode();
    }
}
