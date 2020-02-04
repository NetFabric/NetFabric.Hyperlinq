using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereSelectCountBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(linqRange, item => (item & 0x01) == 0), item => item));

        [BenchmarkCategory("LinkedList")]
        [Benchmark(Baseline = true)]
        public int Linq_LinkedList() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(linkedList, item => (item & 0x01) == 0), item => item));

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(array, item => (item & 0x01) == 0), item => item));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(list, item => (item & 0x01) == 0), item => item));

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(enumerableReference, item => (item & 0x01) == 0), item => item));

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(enumerableValue, item => (item & 0x01) == 0), item => item));

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
            => hyperlinqRange.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("LinkedList")]
        [Benchmark]
        public int Hyperlinq_LinkedList() 
            => linkedList.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
            => array.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span()
            => array.AsSpan().Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory()
            => array.AsMemory().Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
            => list.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference
            .AsValueEnumerable()
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Count();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => enumerableValue
            .AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerable => enumerable.GetEnumerator())
            .Where(item => (item & 0x01) == 0)
            .Select(item => item)
            .Count();
    }
}
