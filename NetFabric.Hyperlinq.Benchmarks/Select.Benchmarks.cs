using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SelectBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Select(array, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Select(enumerableValue, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Select(collectionValue, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Select(listValue, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Select(enumerableReference, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Select(collectionReference, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Select(listReference, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_Array()
        {
            var count = 0;
            foreach (var item in array.SelectF(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var count = 0;
            foreach (var item in array.Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
        {
            var count = 0;
            foreach (var item in array.AsSpan().Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            var count = 0;
            foreach (var item in memory.Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_ForEach()
        {
            var count = 0;
            array.AsSpan().Select(item => item).ForEach(_ => count++);
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value_ForEach()
        {
            var count = 0;
            Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item)
                .ForEach(_ => count++);
            return count;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value_ForEach()
        {
            var count = 0;
            Enumerable.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item)
                .ForEach(_ => count++);
            return count;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value_ForEach()
        {
            var count = 0;
            Enumerable.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator())
                .Select(item => item)
                .ForEach(_ => count++);
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in enumerableReference.AsValueEnumerable().Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference_ForEach()
        {
            var count = 0;
            enumerableReference
                .AsValueEnumerable()
                .Select(item => item)
                .ForEach(_ => count++);
            return count;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var count = 0;
            foreach (var item in collectionReference.AsValueEnumerable().Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference_ForEach()
        {
            var count = 0;
            collectionReference
                .AsValueEnumerable()
                .Select(item => item)
                .ForEach(_ => count++);
            return count;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            var count = 0;
            foreach (var item in listReference.AsValueEnumerable().Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference_ForEach()
        {
            var count = 0;
            listReference
                .AsValueEnumerable()
                .Select(item => item)
                .ForEach(_ => count++);
            return count;
        }
    }
}
