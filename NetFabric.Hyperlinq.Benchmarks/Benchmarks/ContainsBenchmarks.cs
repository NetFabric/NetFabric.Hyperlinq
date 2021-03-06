using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class ContainsBenchmarks : SequentialBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() 
            => array.Contains(Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() 
            => enumerableValue.Contains(Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value() 
            => Enumerable.Contains(collectionValue, Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value() 
            => Enumerable.Contains(listValue, Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Value()
            => asyncEnumerableValue.ContainsAsync(Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() 
            => enumerableReference.Contains(Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference() 
            => collectionReference.Contains(Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference() 
            => listReference.Contains(Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Reference()
            => asyncEnumerableReference.ContainsAsync(Count - 1);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() 
            => array.AsValueEnumerable().Contains(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span() 
            => array.AsSpan().AsValueEnumerable().Contains(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span_SIMD()
            => array.AsSpan().AsValueEnumerable().ContainsVector(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory() 
            => memory.AsValueEnumerable().Contains(Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() 
            => enumerableValue.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerable => enumerable.GetEnumerator())
                .Contains(Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value() 
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Contains(Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value() 
            => listValue
                .AsValueEnumerable()
                .Contains(Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<bool> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
                .ContainsAsync(Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() 
            => enumerableReference
                .AsValueEnumerable()
                .Contains(Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool Hyperlinq_Collection_Reference() 
            => collectionReference
                .AsValueEnumerable()
                .Contains(Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool Hyperlinq_List_Reference() 
            => listReference
                .AsValueEnumerable()
                .Contains(Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<bool> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .ContainsAsync(Count - 1);
    }
}
