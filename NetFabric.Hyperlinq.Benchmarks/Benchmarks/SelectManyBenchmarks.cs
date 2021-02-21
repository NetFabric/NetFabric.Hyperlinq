using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class SelectManyBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var sum = 0;
            foreach (var item in Enumerable.SelectMany(array, item => EnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.SelectMany(enumerableValue, item => EnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.SelectMany(collectionValue, item => EnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.SelectMany(listValue, item => EnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public async Task<int> Linq_AsyncEnumerable_Value()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.SelectMany(asyncEnumerableValue, item => AsyncEnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.SelectMany(enumerableReference, item => EnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.SelectMany(collectionReference, item => EnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.SelectMany(listReference, item => EnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public async Task<int> Linq_AsyncEnumerable_Reference()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.SelectMany(asyncEnumerableReference, item => AsyncEnumerableEx.Return(item)))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var sum = 0;
            foreach (var item in array.AsValueEnumerable().SelectMany<ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            var sum = 0;
            foreach (var item in memory.AsValueEnumerable().SelectMany<ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .SelectMany(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .SelectMany(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue
                .AsValueEnumerable()
                .SelectMany(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference
                .AsValueEnumerable()
                .SelectMany(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference
                .AsValueEnumerable()
                .SelectMany(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference
                .AsValueEnumerable()
                .SelectMany(item => ValueEnumerable.Return(item)))
                sum += item;
            return sum;
        }
    }
}
