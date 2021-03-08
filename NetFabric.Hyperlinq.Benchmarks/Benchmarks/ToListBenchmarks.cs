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
    public class ToListBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array()
            => array.ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value()
            => enumerableValue.ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Value()
            => collectionValue.ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Value()
            => listValue.ToList();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<List<int>> Linq_AsyncEnumerable_Value()
            => asyncEnumerableValue.ToListAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference()
            => enumerableReference.ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Reference()
            => collectionReference.ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Reference()
            => listReference.ToList();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<List<int>> Linq_AsyncEnumerable_Reference()
            => asyncEnumerableReference.ToListAsync();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> StructLinq_Array()
            => array
                .ToStructEnumerable()
                .ToList(x => x);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> StructLinq_Enumerable_Value()
            => enumerableValue
                .ToStructEnumerable()
                .ToList(x => x);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> StructLinq_Collection_Value()
            => collectionValue
                .ToStructEnumerable()
                .ToList(x => x);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> StructLinq_List_Value()
            => listValue
                .ToStructEnumerable()
                .ToList(x => x);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> StructLinq_Enumerable_Reference()
            => enumerableReference
                .ToStructEnumerable()
                .ToList(x => x);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> StructLinq_Collection_Reference()
            => collectionReference
                .ToStructEnumerable()
                .ToList(x => x);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> StructLinq_List_Reference()
            => listReference
                .ToStructEnumerable()
                .ToList(x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array()
            => array.AsValueEnumerable()
                .ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable()
                .ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Value()
            => collectionValue.AsValueEnumerable()
                .ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable()
                .ToListAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .ToList();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .ToListAsync();
    }
}
