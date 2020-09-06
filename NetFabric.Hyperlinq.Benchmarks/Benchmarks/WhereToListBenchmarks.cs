using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class WhereToListBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array()
            => Enumerable.Where(array, item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value()
            => Enumerable.Where(enumerableValue, item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Value()
            => Enumerable.Where(collectionValue, item => item.IsEven())
                .ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Value()
            => Enumerable.Where(listValue, item => item.IsEven())
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<List<int>> Linq_AsyncEnumerable_Value()
            => AsyncEnumerable.Where(asyncEnumerableValue, item => item.IsEven())
                .ToListAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference()
            => Enumerable.Where(enumerableReference, item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Reference()
            => Enumerable.Where(collectionReference, item => item.IsEven())
                .ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Reference()
            => Enumerable.Where(listReference, item => item.IsEven())
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<List<int>> Linq_AsyncEnumerable_Reference()
            => AsyncEnumerable.Where(asyncEnumerableReference, item => item.IsEven())
                .ToListAsync();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> StructLinq_Array()
            => array
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .ToList(x => x);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> StructLinq_Enumerable_Value()
            => enumerableValue
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .ToList(x => x);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> StructLinq_Collection_Value()
            => collectionValue
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .ToList(x => x);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> StructLinq_List_Value()
            => listValue
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .ToList(x => x);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> StructLinq_Enumerable_Reference()
            => enumerableReference
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .ToList(x => x);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> StructLinq_Collection_Reference()
            => collectionReference
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .ToList(x => x);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> StructLinq_List_Reference()
            => listReference
                .ToStructEnumerable()
                .Where(item => item.IsEven(), x => x)
                .ToList(x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array()
            => array
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Span()
            => array.AsSpan()
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Memory()
            => memory
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value()
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
                .Where(item => item.IsEven())
                .ToListAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .Where(item => item.IsEven())
                .ToListAsync();
    }
}
