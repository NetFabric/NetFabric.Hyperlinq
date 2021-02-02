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
    public class SumBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => Enumerable.Sum(array);

        //[BenchmarkCategory("Enumerable_Value")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Enumerable_Value()
        //    => Enumerable.Sum(enumerableValue);

        //[BenchmarkCategory("Collection_Value")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Collection_Value()
        //    => Enumerable.Sum(collectionValue);

        //[BenchmarkCategory("List_Value")]
        //[Benchmark(Baseline = true)]
        //public int Linq_List_Value()
        //    => Enumerable.Sum(listValue);

        //[BenchmarkCategory("AsyncEnumerable_Value")]
        //[Benchmark(Baseline = true)]
        //public ValueTask<int> Linq_AsyncEnumerable_Value()
        //    => AsyncEnumerable.SumAsync(asyncEnumerableValue);

        //[BenchmarkCategory("Enumerable_Reference")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Enumerable_Reference()
        //    => Enumerable.Sum(enumerableReference);

        //[BenchmarkCategory("Collection_Reference")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Collection_Reference()
        //    => Enumerable.Sum(collectionReference);

        //[BenchmarkCategory("List_Reference")]
        //[Benchmark(Baseline = true)]
        //public int Linq_List_Reference()
        //    => Enumerable.Sum(listReference);

        //[BenchmarkCategory("AsyncEnumerable_Reference")]
        //[Benchmark(Baseline = true)]
        //public ValueTask<int> Linq_AsyncEnumerable_Reference()
        //    => AsyncEnumerable.SumAsync(asyncEnumerableReference);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Array()
            => array
                .ToStructEnumerable()
                .Sum(x => x);

        //[BenchmarkCategory("Enumerable_Value")]
        //[Benchmark]
        //public int StructLinq_Enumerable_Value()
        //    => enumerableValue
        //        .ToStructEnumerable()
        //        .Sum(x => x);

        //[BenchmarkCategory("Collection_Value")]
        //[Benchmark]
        //public int StructLinq_Collection_Value()
        //    => collectionValue
        //        .ToStructEnumerable()
        //        .Sum(x => x);

        //[BenchmarkCategory("List_Value")]
        //[Benchmark]
        //public int StructLinq_List_Value()
        //    => listValue
        //        .ToStructEnumerable()
        //        .Sum(x => x);

        //[BenchmarkCategory("Enumerable_Reference")]
        //[Benchmark]
        //public int StructLinq_Enumerable_Reference()
        //    => enumerableReference
        //        .ToStructEnumerable()
        //        .Sum(x => x);

        //[BenchmarkCategory("Collection_Reference")]
        //[Benchmark]
        //public int StructLinq_Collection_Reference()
        //    => collectionReference
        //        .ToStructEnumerable()
        //        .Sum(x => x);

        //[BenchmarkCategory("List_Reference")]
        //[Benchmark]
        //public int StructLinq_List_Reference()
        //    => listReference
        //        .ToStructEnumerable()
        //        .Sum(x => x);

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
            => array.Sum();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
            => array.AsSpan().Sum();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
            => memory.Sum();

        //[BenchmarkCategory("Enumerable_Value")]
        //[Benchmark]
        //public int Hyperlinq_Enumerable_Value()
        //    => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
        //        .Sum();

        //[BenchmarkCategory("Collection_Value")]
        //[Benchmark]
        //public int Hyperlinq_Collection_Value()
        //    => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
        //        .Sum();

        //[BenchmarkCategory("List_Value")]
        //[Benchmark]
        //public int Hyperlinq_List_Value()
        //    => listValue
        //        .AsValueEnumerable()
        //        .Sum();

        //[BenchmarkCategory("AsyncEnumerable_Value")]
        //[Benchmark]
        //public ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
        //    => asyncEnumerableValue
        //        .AsAsyncValueEnumerable<TestAsyncEnumerable.Enumerable, TestAsyncEnumerable.Enumerable.Enumerator, int>((enumerable, cancellationToke) => enumerable.GetAsyncEnumerator(cancellationToke))
        //        .SumAsync();

        //[BenchmarkCategory("Enumerable_Reference")]
        //[Benchmark]
        //public int Hyperlinq_Enumerable_Reference()
        //    => enumerableReference
        //        .AsValueEnumerable()
        //        .Sum();

        //[BenchmarkCategory("Collection_Reference")]
        //[Benchmark]
        //public int Hyperlinq_Collection_Reference()
        //    => collectionReference
        //        .AsValueEnumerable()
        //        .Sum();

        //[BenchmarkCategory("List_Reference")]
        //[Benchmark]
        //public int Hyperlinq_List_Reference()
        //    => listReference
        //        .AsValueEnumerable()
        //        .Sum();

        //[BenchmarkCategory("AsyncEnumerable_Reference")]
        //[Benchmark]
        //public ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
        //    => asyncEnumerableReference
        //        .AsAsyncValueEnumerable()
        //        .SumAsync();
    }
}
