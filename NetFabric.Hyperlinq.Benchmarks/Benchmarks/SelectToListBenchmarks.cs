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
    public class SelectToListBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List()
            => Enumerable.Select(array, item => item).ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value()
            => Enumerable.Select(enumerableValue, item => item).ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Value()
            => Enumerable.Select(collectionValue, item => item).ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Value()
            => Enumerable.Select(listValue, item => item).ToList();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference()
            => Enumerable.Select(enumerableReference, item => item).ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Reference()
            => Enumerable.Select(collectionReference, item => item).ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Reference()
            => Enumerable.Select(listReference, item => item).ToList();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> StructLinq_List()
            => array
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToList(x => x);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> StructLinq_Enumerable_Value()
            => enumerableValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToList(x => x);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> StructLinq_Collection_Value()
            => collectionValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToList(x => x);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> StructLinq_List_Value()
            => listValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToList(x => x);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> StructLinq_Enumerable_Reference()
            => enumerableReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToList(x => x);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> StructLinq_Collection_Reference()
            => collectionReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToList(x => x);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> StructLinq_List_Reference()
            => listReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToList(x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_List()
            => array
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Span()
            => array.AsSpan().AsValueEnumerable()
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Memory()
            => memory.AsValueEnumerable()
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value()
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
                .Select(item => item)
                .ToListAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Select(item => item)
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .Select(item => item)
                .ToListAsync();
    }
}
