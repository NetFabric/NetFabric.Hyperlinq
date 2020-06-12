using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToArrayBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Array() =>
            System.Linq.Enumerable.ToArray(array);

#if SPAN_SUPPORTED
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] System_Span() =>
            array.AsSpan().ToArray();
#endif

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
        public int[] Hyperlinq_Array() =>
            array.ToArray();

#if SPAN_SUPPORTED
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Span() =>
            array.AsSpan().ToArray();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Memory() =>
            memory.ToArray();
#endif

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Value() =>
            EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .ToArray();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Value() =>
            ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .ToArray();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int[] Hyperlinq_List_Value() =>
            ReadOnlyListExtensions.AsValueEnumerable<int>(listValue)
            .ToArray();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_AsyncEnumerable_Value() =>
            AsyncEnumerableExtensions.AsAsyncValueEnumerable<TestAsyncEnumerable.AsyncEnumerable, TestAsyncEnumerable.AsyncEnumerable.AsyncEnumerator, int>(
                asyncEnumerableValue, 
                (enumerable, cancellationToken) => enumerable.GetAsyncEnumerator(cancellationToken))
            .ToArrayAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int[] Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int[] Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .ToArray();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<int[]> Hyperlinq_AsyncEnumerable_Reference() =>
            asyncEnumerableReference
            .AsAsyncValueEnumerable()
            .ToArrayAsync();
    }
}
