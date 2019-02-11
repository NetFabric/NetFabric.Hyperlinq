using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class ToListBenchmarks
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

        [Params(0, 100, 10_000)]
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
        public List<int> Linq_Array() => 
            System.Linq.Enumerable.ToList(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_List() => 
            System.Linq.Enumerable.ToList(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Range() => 
            System.Linq.Enumerable.ToList(linqRange);

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public List<int> Linq_Enumerable() => 
            System.Linq.Enumerable.ToList(enumerable);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public List<int> Hyperlinq_Array() => 
            array.ToList();

        [BenchmarkCategory("List")]
        [Benchmark]
        public List<int> Hyperlinq_List() => 
            list.ToList();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public List<int> Hyperlinq_Range() =>
            hyperlinqRange.ToList();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public List<int> Hyperlinq_Enumerable() => 
            enumerable.ToList();
    }
}
