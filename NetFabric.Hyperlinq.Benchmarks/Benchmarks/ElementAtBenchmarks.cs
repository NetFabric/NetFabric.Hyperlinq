using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class ElementAtBenchmarks: SequentialBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => Enumerable.ElementAt(array, Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => Enumerable.ElementAt(enumerableValue, Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
            => Enumerable.ElementAt(collectionValue, Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
            => Enumerable.ElementAt(listValue, Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Value()
            => AsyncEnumerable.ElementAtAsync(asyncEnumerableValue, Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
            => Enumerable.ElementAt(enumerableReference, Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
            => Enumerable.ElementAt(collectionReference, Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
            => Enumerable.ElementAt(listReference, Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Reference()
            => AsyncEnumerable.ElementAtAsync(asyncEnumerableReference, Count - 1);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Array()
            => array.AsValueEnumerable().ElementAt(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Span()
            => array.AsSpan().AsValueEnumerable().ElementAt(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Memory()
            => memory.AsValueEnumerable().ElementAt(Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Value()
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .ElementAt(Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .ElementAt(Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .ElementAt(Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .ElementAt(Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .ElementAt(Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .ElementAt(Count - 1);
    }
}
