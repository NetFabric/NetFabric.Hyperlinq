using System;
using System.Buffers;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereToArrayArrayPoolBenchmarks: BenchmarksBase
    {
        readonly MemoryPool<int> memoryPool = MemoryPool<int>.Shared;

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() =>
            Enumerable.ToArray(Enumerable.Where(array, item => (item & 0x01) == 0));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value() =>
            Enumerable.ToArray(Enumerable.Where(enumerableValue, item => (item & 0x01) == 0));

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Value() =>
            Enumerable.ToArray(Enumerable.Where(collectionValue, item => (item & 0x01) == 0));

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Value() =>
            Enumerable.ToArray(Enumerable.Where(listValue, item => (item & 0x01) == 0));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference() =>
            Enumerable.ToArray(Enumerable.Where(enumerableReference, item => (item & 0x01) == 0));

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Reference() =>
            Enumerable.ToArray(Enumerable.Where(collectionReference, item => (item & 0x01) == 0));

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Reference() =>
            Enumerable.ToArray(Enumerable.Where(listReference, item => (item & 0x01) == 0));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            using var memoryOwner = array
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            using var memoryOwner = memory
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            using var memoryOwner = EnumerableExtensions
                .AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            using var memoryOwner = ReadOnlyCollectionExtensions
                .AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            using var memoryOwner = ReadOnlyListExtensions
                .AsValueEnumerable<int>(listValue)
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        // TODO: uncomment (requires fixes in the generator)
        //[BenchmarkCategory("AsyncEnumerable_Value")]
        //[Benchmark]
        //public async ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
        //{
        //    using var memoryOwner = await AsyncEnumerableExtensions
        //        .AsAsyncValueEnumerable<TestAsyncEnumerable.AsyncEnumerable, TestAsyncEnumerable.AsyncEnumerable.AsyncEnumerator, int>(
        //            asyncEnumerableValue,
        //            (enumerable, cancellationToken) => enumerable.GetAsyncEnumerator(cancellationToken))
        //        .Where(item => (item & 0x01) == 0)
        //        .ToArrayAsync(memoryPool);
        //    return memoryOwner.Memory.Span[0];
        //}

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            using var memoryOwner = enumerableReference
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            using var memoryOwner = collectionReference
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            using var memoryOwner = listReference
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        // TODO: uncomment (requires fixes in the generator)
        //[BenchmarkCategory("AsyncEnumerable_Reference")]
        //[Benchmark]
        //public async ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
        //{
        //    using var memoryOwner = await asyncEnumerableReference
        //        .AsAsyncValueEnumerable()
        //        .Where(item => (item & 0x01) == 0)
        //        .ToArrayAsync(memoryPool);
        //    return memoryOwner.Memory.Span[0];
        //}
    }
}
