using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;
using System.Buffers;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class ToArrayBenchmarks: RandomBenchmarksBase
    {
        
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array()
            => array.ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value()
            => enumerableValue.ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Value()
            => collectionValue.ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Value()
            => listValue.ToArray();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<int[]> Linq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .ToArrayAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference()
            => enumerableReference.ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Reference()
            => collectionReference.ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Reference()
            => listReference.ToArray();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<int[]> Linq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .ToArrayAsync();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] StructLinq_Array()
            => array
                .ToStructEnumerable()
                .ToArray(x => x);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] StructLinq_Enumerable_Value()
            => enumerableValue
                .ToStructEnumerable()
                .ToArray(x => x);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] StructLinq_Collection_Value()
            => collectionValue
                .ToStructEnumerable()
                .ToArray(x => x);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] StructLinq_List_Value()
            => listValue
                .ToStructEnumerable()
                .ToArray(x => x);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] StructLinq_Enumerable_Reference()
            => enumerableReference
                .ToStructEnumerable()
                .ToArray(x => x);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] StructLinq_Collection_Reference()
            => collectionReference
                .ToStructEnumerable()
                .ToArray(x => x);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] StructLinq_List_Reference()
            => listReference
                .ToStructEnumerable()
                .ToArray(x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array()
            => array.AsValueEnumerable()
                .ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable()
                .ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Value()
            => collectionValue.AsValueEnumerable()
                .ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .ToArray();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable()
                .ToArrayAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .ToArray();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .ToArrayAsync();
    }
}
