using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;
using System;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class WhereSelectBenchmarks: RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(array, item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(enumerableValue, item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(collectionValue, item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(listValue, item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(enumerableReference, item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(collectionReference, item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(listReference, item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        // -------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Array()
        {
            var sum = 0;
            foreach (var item in array.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int StructLinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in enumerableValue.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int StructLinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in collectionValue.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int StructLinq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int StructLinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int StructLinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int StructLinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item, x => x))
                sum += item;
            return sum;
        }

        // -------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var sum = 0;
            foreach (var item in array.Where(item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
        {
            var sum = 0;
            foreach (var item in array.AsSpan().Where(item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            var sum = 0;
            foreach (var item in memory.Where(item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item.IsEven())
                .Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Where(item => item.IsEven())
                .Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item))
                sum += item;
            return sum;
        }
    }
}
