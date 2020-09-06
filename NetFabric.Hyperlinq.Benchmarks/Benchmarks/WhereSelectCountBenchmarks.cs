using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class WhereSelectCountBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(array, item => item.IsEven()), item => item));


        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        
            => System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(enumerableValue, item => item.IsEven()), item => item));

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
            => System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(collectionValue, item => item.IsEven()), item => item));

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
            => System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(listValue, item => item.IsEven()), item => item));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        
            => System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(enumerableReference, item => item.IsEven()), item => item));

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
            => System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(collectionReference, item => item.IsEven()), item => item));

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
            => System.Linq.Enumerable.Count(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(listReference, item => item.IsEven()), item => item));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
            => array.Where(item => item.IsEven()).Select(item => item).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
            => array.AsSpan().Where(item => item.IsEven()).Select(item => item).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
            => memory.Where(item => item.IsEven()).Select(item => item).Count();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item.IsEven())
                .Select(item => item)
                .Count();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
            => ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item.IsEven())
                .Select(item => item)
                .Count();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        
            => listValue
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item)
                .Count();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item)
                .Count();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
            => collectionReference  
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item)
                .Count();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item)
                .Count();
    }
}
