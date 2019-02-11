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
    public class ToArrayBenchmarks
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
        public int[] Linq_Array() => 
            System.Linq.Enumerable.ToArray(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int[] Linq_List() => 
            System.Linq.Enumerable.ToArray(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Range() => 
            System.Linq.Enumerable.ToArray(linqRange);

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int[] Linq_Enumerable() => 
            System.Linq.Enumerable.ToArray(enumerable);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int[] Hyperlinq_Array() => 
            array.ToArray();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int[] Hyperlinq_List() => 
            list.ToArray();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int[] Hyperlinq_Range() =>
            hyperlinqRange.ToArray();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int[] Hyperlinq_Enumerable() =>
            enumerable.ToArray();
    }
}
