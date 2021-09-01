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
    public class ToArrayArrayPoolBenchmarks: RandomBenchmarksBase
    {

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Hyperlinq_Array()
        {
            var values = array.AsValueEnumerable().ToArray();
            return values.AsValueEnumerable().Sum();
        }
        
        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Hyperlinq_Enumerable_Value()
        {
            var values = enumerableValue.AsValueEnumerable().ToArray();
            return values.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Hyperlinq_Collection_Value()
        {
            var values = collectionValue.AsValueEnumerable().ToArray();
            return values.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Hyperlinq_List_Value()
        {
            var values = listValue.AsValueEnumerable().ToArray();
            return values.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
        {
            var values = await asyncEnumerableValue.AsAsyncValueEnumerable().ToArrayAsync();
            return values.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Hyperlinq_Enumerable_Reference()
        {
            var values = enumerableReference.AsValueEnumerable().ToArray();
            return values.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Hyperlinq_Collection_Reference()
        {
            var values = collectionReference.AsValueEnumerable().ToArray();
            return values.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Hyperlinq_List_Reference()
        {
            var values = listReference.AsValueEnumerable().ToArray();
            return values.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
        {
            var values = await asyncEnumerableReference.AsAsyncValueEnumerable().ToArrayAsync();
            return values.AsValueEnumerable().Sum();
        }
        
        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_ArrayPool()
        {
            using var values = array.AsValueEnumerable().ToArray(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value_ArrayPool()
        {
            using var values = enumerableValue.AsValueEnumerable().ToArray(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value_ArrayPool()
        {
            using var values = collectionValue.AsValueEnumerable().ToArray(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value_ArrayPool()
        {
            using var values = listValue.AsValueEnumerable().ToArray(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Value_ArrayPool()
        {
            using var values = await asyncEnumerableValue.AsAsyncValueEnumerable().ToArrayAsync(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference_ArrayPool()
        {
            using var values = enumerableReference.AsValueEnumerable().ToArray(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference_ArrayPool()
        {
            using var values = collectionReference.AsValueEnumerable().ToArray(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference_ArrayPool()
        {
            using var values = listReference.AsValueEnumerable().ToArray(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Reference_ArrayPool()
        {
            using var values = await asyncEnumerableReference.AsAsyncValueEnumerable().ToArrayAsync(ArrayPool<int>.Shared);
            return values.Memory.Span.AsValueEnumerable().Sum();
        }

    }
}
