using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class ContainsComparerBenchmarks: SequentialBenchmarksBase, IEqualityComparer<int>
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array()
            => Enumerable.Contains(array, Count - 1, this);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value()
            => Enumerable.Contains(enumerableValue, Count - 1, this);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value()
            => Enumerable.Contains(collectionValue, Count - 1, this);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value()
            => Enumerable.Contains(listValue, Count - 1, this);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Value()
            => AsyncEnumerable.ContainsAsync(asyncEnumerableValue, Count - 1, this);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference()
            => Enumerable.Contains(enumerableReference, Count - 1, this);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference()
            => Enumerable.Contains(collectionReference, Count - 1, this);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference()
            => Enumerable.Contains(listReference, Count - 1, this);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Reference()
            => AsyncEnumerable.ContainsAsync(asyncEnumerableReference, Count - 1, this);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array()
            => array.Contains(Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span()
            => array.AsSpan().Contains(Count - 1, this);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory()
            => memory.AsValueEnumerable().Contains(Count - 1, this);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value()
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Contains(Count - 1, this);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Contains(Count - 1, this);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .Contains(Count - 1, this);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Contains(Count - 1, this);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .Contains(Count - 1, this);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Contains(Count - 1, this);

        // ---------------------------------------------------------------------

        public bool Equals(int x, int y)
            => x == y;

        public int GetHashCode(int obj)
            => obj.GetHashCode();
    }
}
