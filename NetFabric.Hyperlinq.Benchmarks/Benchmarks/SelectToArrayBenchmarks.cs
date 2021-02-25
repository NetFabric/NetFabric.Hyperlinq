using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster.SIMD;
using StructLinq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class SelectToArrayBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() 
            => Enumerable.Select(array, item => item).ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value()
            => Enumerable.Select(enumerableValue, item => item).ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Value()
            => Enumerable.Select(collectionValue, item => item).ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Value()
            => Enumerable.Select(listValue, item => item).ToArray();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference()
            => Enumerable.Select(enumerableReference, item => item).ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Reference()
            => Enumerable.Select(collectionReference, item => item).ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Reference()
            => Enumerable.Select(listReference, item => item).ToArray();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] StructLinq_Array()
            => array
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToArray(x => x);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] StructLinq_Enumerable_Value()
            => enumerableValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToArray(x => x);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] StructLinq_Collection_Value()
            => collectionValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToArray(x => x);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] StructLinq_List_Value()
            => listValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToArray(x => x);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] StructLinq_Enumerable_Reference()
            => enumerableReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToArray(x => x);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] StructLinq_Collection_Reference()
            => collectionReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToArray(x => x);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] StructLinq_List_Reference()
            => listReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .ToArray(x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] LinqFasterSIMD_Array()
            => array
                .SelectS(item => item, x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array() 
            => array.AsValueEnumerable()
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Span() 
            => array.AsSpan()
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Span_SIMD()
            => array.AsSpan()
                .SelectVector(item => item, item => item)
                .ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Memory() 
            => memory.AsValueEnumerable()
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerable => enumerable.GetEnumerator())
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
                .Select(item => item)
                .ToArrayAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Select(item => item)
                .ToArray();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .Select(item => item)
                .ToArrayAsync();
    }
}
