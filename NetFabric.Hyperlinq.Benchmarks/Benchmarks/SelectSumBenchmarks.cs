using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class SelectSumBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => array.Select(item => item)
                .Sum();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => enumerableValue.Select(item => item)
                .Sum();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
            => collectionValue.Select(item => item)
                .Sum();

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
            => listValue.Select(item => item)
                .Sum();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Value()
            => asyncEnumerableValue.Select(item => item)
                .SumAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
            => enumerableReference.Select(item => item)
                .Sum();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
            => collectionReference.Select(item => item)
                .Sum();

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
            => listReference.Select(item => item)
                .Sum();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Reference()
            => asyncEnumerableReference.Select(item => item)
                .SumAsync();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Array()
            => array
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .Sum(x => x);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int StructLinq_Enumerable_Value()
            => enumerableValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .Sum(x => x);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int StructLinq_Collection_Value()
            => collectionValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .Sum(x => x);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int StructLinq_List_Value()
            => listValue
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .Sum(x => x);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int StructLinq_Enumerable_Reference()
            => enumerableReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .Sum(x => x);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int StructLinq_Collection_Reference()
            => collectionReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .Sum(x => x);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int StructLinq_List_Reference()
            => listReference
                .ToStructEnumerable()
                .Select(item => item, x => x)
                .Sum(x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
            => array.AsValueEnumerable()
                .Select(item => item)
                .Sum();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_SIMD()
            => array.AsValueEnumerable()
                .SelectVector(item => item, item => item)
                .Sum();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable()
                .Select(item => item)
                .Sum();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
            => collectionValue.AsValueEnumerable()
                .Select(item => item)
                .Sum();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
            => listValue
                .AsValueEnumerable()
                .Select(item => item)
                .Sum();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable()
                .Select((item, _) => new ValueTask<int>(item))
                .SumAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Select(item => item)
                .Sum();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
            => collectionReference
                .AsValueEnumerable()
                .Select(item => item)
                .Sum();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Select(item => item)
                .Sum();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .Select((item, _) => new ValueTask<int>(item))
                .SumAsync();
    }
}
