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
    public class DistinctBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(array))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(enumerableValue))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(collectionValue))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(listValue))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public async Task<int> Linq_AsyncEnumerable_Value()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.Distinct(asyncEnumerableValue))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(enumerableReference))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(collectionReference))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.Distinct(listReference))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public async Task<int> Linq_AsyncEnumerable_Reference()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.Distinct(asyncEnumerableReference))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Array()
        {
            var sum = 0;
            foreach (var item in array.Distinct(x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int StructLinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in enumerableValue.ToStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int StructLinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in collectionValue.ToStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int StructLinq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue.ToStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int StructLinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.ToStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int StructLinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.ToStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int StructLinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.ToStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var sum = 0;
            foreach (var item in array.Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
        {
            var sum = 0;
            foreach (ref readonly var item in array.AsSpan().Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            var sum = 0;
            foreach (var item in memory.AsValueEnumerable().Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator()).Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator()).Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue.AsValueEnumerable().Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public async Task<int> Hyperlinq_AsyncEnumerable_Value()
        {
            var sum = 0;
            await foreach (var item in asyncEnumerableValue.AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke)).Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.AsValueEnumerable().Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.AsValueEnumerable().Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.AsValueEnumerable().Distinct())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public async Task<int> Hyperlinq_AsyncEnumerable_Reference()
        {
            var sum = 0;
            await foreach (var item in asyncEnumerableReference.AsAsyncValueEnumerable().Distinct())
                sum += item;
            return sum;
        }
    }
}
