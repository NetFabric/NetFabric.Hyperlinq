using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using StructLinq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(array, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(enumerableValue, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(collectionValue, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(listValue, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_AsyncEnumerable_Value()
        {
            var sum = 0;
            await foreach (var item in System.Linq.AsyncEnumerable.Where<int>(asyncEnumerableValue, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(enumerableReference, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(collectionReference, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(listReference, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_AsyncEnumerable_Reference()
        {
            var sum = 0;
            await foreach (var item in System.Linq.AsyncEnumerable.Where<int>(asyncEnumerableReference, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        // -------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Array()
        {
            var sum = 0;
            foreach (var item in array.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int StructLinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in enumerableValue.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int StructLinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in collectionValue.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int StructLinq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int StructLinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int StructLinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int StructLinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        // -------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var sum = 0;
            foreach (var item in array.Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
        {
            var sum = 0;
            foreach (var item in array.AsSpan().Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            var sum = 0;
            foreach (var item in memory.Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator()).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator()).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            var sum = 0;
            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator()).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerableExtensions
                .AsAsyncValueEnumerable<TestAsyncEnumerable.AsyncEnumerable, TestAsyncEnumerable.AsyncEnumerable.AsyncEnumerator, int>(asyncEnumerableValue, (enumerable, cancellationToken) => enumerable.GetAsyncEnumerator(cancellationToken))
                .Where((item, _) => new ValueTask<bool>((item & 0x01) == 0)))
            {
                sum += item;
            }
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.AsValueEnumerable().Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.AsValueEnumerable().Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.AsValueEnumerable().Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
        {
            var sum = 0;
            await foreach (var item in asyncEnumerableReference.AsAsyncValueEnumerable().Where((item, _) => new ValueTask<bool>((item & 0x01) == 0)))
                sum += item;
            return sum;
        }
    }
}
