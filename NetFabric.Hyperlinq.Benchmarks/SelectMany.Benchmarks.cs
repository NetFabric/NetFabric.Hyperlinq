using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SelectManyBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.SelectMany(array, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.SelectMany(enumerableValue, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.SelectMany(collectionValue, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.SelectMany(listValue, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.SelectMany(enumerableReference, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.SelectMany(collectionReference, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.SelectMany(listReference, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_Array() 
        { 
            var count = 0;
            foreach(var item in array.SelectManyF(item => new[] { item }))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var count = 0;
            foreach (var item in array.SelectMany<int, ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .SelectMany<
                    Enumerable.ValueEnumerableWrapper<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>, TestEnumerable.Enumerable.Enumerator, int, 
                    ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .SelectMany<
                    Enumerable.ValueEnumerableWrapper<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>, TestCollection.Enumerable.Enumerator, int,
                    ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator())
                .SelectMany<
                    Enumerable.ValueEnumerableWrapper<TestList.Enumerable, TestList.Enumerable.Enumerator, int>, TestList.Enumerable.Enumerator, int,
                    ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in enumerableReference.AsValueEnumerable()
                .SelectMany<
                    Enumerable.ValueEnumerableWrapper<int>, Enumerable.ValueEnumerableWrapper<int>.Enumerator, int,
                    ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var count = 0;
            foreach (var item in collectionReference.AsValueEnumerable()
                .SelectMany<
                    ReadOnlyCollection.ValueEnumerableWrapper<int>, ReadOnlyCollection.ValueEnumerableWrapper<int>.Enumerator, int,
                    ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            var count = 0;
            foreach (var item in ReadOnlyList.SelectMany<
                    ReadOnlyList.ValueEnumerableWrapper<IReadOnlyList<int>, int>, int, 
                    ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.DisposableEnumerator, int>(
                        ReadOnlyList.AsValueEnumerable<IReadOnlyList<int>, int>(listReference), item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }
    }
}
