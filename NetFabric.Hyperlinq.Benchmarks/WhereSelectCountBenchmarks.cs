using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class WhereSelectCountBenchmarks
    {
        int[] array;
        List<int> list;
        IEnumerable<int> linqRange;
        Enumerable.RangeReadOnlyList hyperlinqRange;
        IEnumerable<int> enumerable;

        static IEnumerable<int> MyEnumerable(int count)
        {
            for(var value = 0; value < count; value++)
                yield return value;
        }

        [Params(0, 100, 1_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            linqRange = System.Linq.Enumerable.Range(0, Count);
            hyperlinqRange = Enumerable.Range(0, Count);
            array = System.Linq.Enumerable.ToArray(linqRange);
            list = System.Linq.Enumerable.ToList(linqRange);
            enumerable = MyEnumerable(Count);
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_Where_Select() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(array, _ => true), item => item));

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Where_Select() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(list, _ => true), item => item));

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range_Where_Select() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(linqRange, _ => true), item => item));

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Where_Select() 
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(enumerable, _ => true), item => item));

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_Where_Select() 
            => array.Where(_ => true).Select(item => item).Count();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List_Where_Select() 
            => list.Where(_ => true).Select(item => item).Count();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_Where_Select() 
            => hyperlinqRange.Where(_ => true).Select(item => item).Count();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Where_Select() 
            => enumerable.Where(_ => true).Select(item => item).Count();
    }
}
