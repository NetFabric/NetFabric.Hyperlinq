using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToListBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Array() =>
            System.Linq.Enumerable.ToList(array);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ToList(enumerableValue);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Value() =>
            System.Linq.Enumerable.ToList(collectionValue);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Value() =>
            System.Linq.Enumerable.ToList(listValue);

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<List<int>> Linq_AsyncEnumerable_Value() =>
            System.Linq.AsyncEnumerable.ToListAsync(asyncEnumerableValue);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.ToList(enumerableReference);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Collection_Reference() =>
            System.Linq.Enumerable.ToList(collectionReference);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List_Reference() =>
            System.Linq.Enumerable.ToList(listReference);

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<List<int>> Linq_AsyncEnumerable_Reference() =>
            System.Linq.AsyncEnumerable.ToListAsync(asyncEnumerableReference);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array() =>
            array.ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Span() =>
            array.AsSpan().ToList();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Memory() =>
            memory.ToList();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Value() =>
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .ToList();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Value() =>
            ReadOnlyCollection.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .ToList();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public List<int> Hyperlinq_List_Value() =>
            ReadOnlyList.AsValueEnumerable<int>(listValue)
            .ToList();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Value() =>
            AsyncEnumerable.AsAsyncValueEnumerable<TestAsyncEnumerable.AsyncEnumerable, TestAsyncEnumerable.AsyncEnumerable.AsyncEnumerator, int>(
                asyncEnumerableValue, 
                (enumerable, cancellationToken) => enumerable.GetAsyncEnumerator(cancellationToken))
            .ToListAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .ToList();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .ToList();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public List<int> Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .ToList();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<List<int>> Hyperlinq_AsyncEnumerable_Reference() =>
            asyncEnumerableReference
            .AsAsyncValueEnumerable()
            .ToListAsync();
    }
}
