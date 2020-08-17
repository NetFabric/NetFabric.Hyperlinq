using System;
using System.Buffers;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToArrayMemoryPoolBenchmarks: BenchmarksBase
    {
        readonly MemoryPool<int> memoryPool = MemoryPool<int>.Shared;

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() =>
            System.Linq.Enumerable.ToArray(array);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] System_Span() =>
            array.AsSpan().ToArray();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToArray(enumerableValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Value() =>
            System.Linq.Enumerable.ToArray(collectionValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Value() =>
            System.Linq.Enumerable.ToArray(listValue);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<int[]> Linq_AsyncEnumerable_Value() =>
            System.Linq.AsyncEnumerable.ToArrayAsync(asyncEnumerableValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToArray(enumerableReference);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Collection_Reference() =>
            System.Linq.Enumerable.ToArray(collectionReference);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List_Reference() =>
            System.Linq.Enumerable.ToArray(listReference);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<int[]> Linq_AsyncEnumerable_Reference() =>
            System.Linq.AsyncEnumerable.ToArrayAsync(asyncEnumerableReference);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            using var memoryOwner = array
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            using var memoryOwner = memory
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            using var memoryOwner = EnumerableExtensions
                .AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            using var memoryOwner = ReadOnlyCollectionExtensions
                .AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            using var memoryOwner = 
                listValue
                .AsValueEnumerable()
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
        {
            using var memoryOwner = await AsyncEnumerableExtensions
                .AsAsyncValueEnumerable<TestAsyncEnumerable.AsyncEnumerable, TestAsyncEnumerable.AsyncEnumerable.AsyncEnumerator, int>(
                    asyncEnumerableValue,
                    (enumerable, cancellationToken) => enumerable.GetAsyncEnumerator(cancellationToken))
                .ToArrayAsync(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            using var memoryOwner = enumerableReference
                .AsValueEnumerable()
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            using var memoryOwner = collectionReference
                .AsValueEnumerable()
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            using var memoryOwner = listReference
                .AsValueEnumerable()
                .ToArray(memoryPool);
            return memoryOwner.Memory.Span[0];
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
        {
            using var memoryOwner = await asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .ToArrayAsync(memoryPool);
            return memoryOwner.Memory.Span[0];
        }
    }
}
