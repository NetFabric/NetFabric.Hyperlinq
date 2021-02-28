using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class WhereSingleBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => Enumerable.Single(array, item => item == Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => Enumerable.Single(enumerableValue, item => item == Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
            => Enumerable.Single(collectionValue, item => item == Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
            => Enumerable.Single(listValue, item => item == Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Value()
            => AsyncEnumerable.SingleAsync(asyncEnumerableValue, item => item == Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
            => Enumerable.Single(enumerableReference, item => item == Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
            => Enumerable.Single(collectionReference, item => item == Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
            => Enumerable.Single(listReference, item => item == Count - 1);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Reference()
            => AsyncEnumerable.SingleAsync(asyncEnumerableReference, item => item == Count - 1);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Array()
            => array.AsValueEnumerable()
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Span()
            => array.AsSpan().AsValueEnumerable()
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Memory()
            => memory.AsValueEnumerable()
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Value()
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
                .Where(item => item == Count - 1)
                .SingleAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Where(item => item == Count - 1)
                .Single();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .Where(item => item == Count - 1)
                .SingleAsync();
    }
}
