using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class AnyPredicateBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array()
            => Enumerable.Any(array, _ => false);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value()
            => Enumerable.Any(enumerableValue, _ => false);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value()
            => Enumerable.Any(collectionValue, _ => false);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value()
            => Enumerable.Any(listValue, _ => false);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Value()
            => AsyncEnumerable.AnyAsync(asyncEnumerableValue, _ => false);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference()
            => Enumerable.Any(enumerableReference, _ => false);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference()
            => Enumerable.Any(collectionReference, _ => false);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference()
            => Enumerable.Any(listReference, _ => false);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Reference()
            => AsyncEnumerable.AnyAsync(asyncEnumerableReference, _ => false);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array()
            => array
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span()
            => array.AsSpan()
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory()
            => memory
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value()
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<bool> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
                .Where((item, _) => new ValueTask<bool>(item.IsEven()))
                .AnyAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Where(_ => false)
                .Any();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<bool> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .Where((item, _) => new ValueTask<bool>(item.IsEven()))
                .AnyAsync();
    }
}
