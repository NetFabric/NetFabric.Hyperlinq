using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereWhereBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(linqRange, item => (item & 0x01) == 0), item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("LinkedList")]
        [Benchmark(Baseline = true)]
        public int Linq_LinkedList()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(linkedList, item => (item & 0x01) == 0), item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(array, item => (item & 0x01) == 0), item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(list, item => (item & 0x01) == 0), item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(enumerableReference, item => (item & 0x01) == 0), item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(enumerableValue, item => (item & 0x01) == 0), item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range()
        {
            var sum = 0;
            foreach (var item in hyperlinqRange.Where(item => (item & 0x01) == 0).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("LinkedList")]
        [Benchmark]
        public int Hyperlinq_LinkedList()
        {
            var sum = 0;
            foreach (var item in linkedList.Where(item => (item & 0x01) == 0).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
#if SPAN_SUPPORTED
            var sum = 0;
            foreach (ref readonly var item in array.Where(item => (item & 0x01) == 0).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
#else
            var sum = 0;
            foreach (var item in array.Where(item => (item & 0x01) == 0).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
#endif
        }

#if SPAN_SUPPORTED
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
        {
            var sum = 0;
            foreach (ref readonly var item in array.AsSpan().Where(item => (item & 0x01) == 0).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
        {
            var sum = 0;
            foreach (ref readonly var item in memory.Where(item => (item & 0x01) == 0).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }
#endif

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List()
        {
            var sum = 0;
            foreach (var item in list.Where(item => (item & 0x01) == 0).Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in enumerableValue
                .AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerable => enumerable.GetEnumerator())
                .Where(item => (item & 0x01) == 0)
                .Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }
    }
}
