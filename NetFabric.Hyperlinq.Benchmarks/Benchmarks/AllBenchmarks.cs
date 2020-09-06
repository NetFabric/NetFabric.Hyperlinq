using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class AllBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public bool Linq_Array() 
            => Enumerable.All(array, _ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Value() 
            => Enumerable.All(enumerableValue, _ => true);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Value() 
            => Enumerable.All(collectionValue, _ => true);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Value() 
            => Enumerable.All(listValue, _ => true);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Value() 
            => AsyncEnumerable.AllAsync(asyncEnumerableValue, _ => true);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Enumerable_Reference() 
            => Enumerable.All(enumerableReference, _ => true);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_Collection_Reference() 
            => Enumerable.All(collectionReference, _ => true);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public bool Linq_List_Reference() 
            => Enumerable.All(listReference, _ => true);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq_AsyncEnumerable_Reference() 
            => AsyncEnumerable.AllAsync(asyncEnumerableReference, _ => true);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Array() 
            => array.All(_ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Span()
            => array.AsSpan().All(_ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public bool Hyperlinq_Memory() 
            => memory.All(_ => true);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Value() 
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .All(_ => true);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public bool Hyperlinq_Collection_Value() 
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .All(_ => true);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public bool Hyperlinq_List_Value() 
            => listValue
                .AsValueEnumerable()
                .All(_ => true);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<bool> Hyperlinq_AsyncEnumerable_Value() 
            => asyncEnumerableValue
                .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
                .AllAsync((item, _) => new ValueTask<bool>(item.IsEven()));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public bool Hyperlinq_Enumerable_Reference() 
            => enumerableReference
                .AsValueEnumerable()
                .All(_ => true);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public bool Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .All(_ => true);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public bool Hyperlinq_List_Reference() 
            => listReference
                .AsValueEnumerable()
                .All(_ => true);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<bool> Hyperlinq_AsyncEnumerable_Reference() 
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .AllAsync((item, _) => new ValueTask<bool>(item.IsEven()));
    }
}
