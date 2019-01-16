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
    public class CountBenchmarks
    {
        int[] array;
        List<int> list;
        Enumerable.RangeEnumerable range;
        IEnumerable<int> arrayAsEnumerable;
        IEnumerable<int> listAsEnumerable;
        IEnumerable<int> rangeAsEnumerable;
        IEnumerable<int> enumerable;

        static IEnumerable<int> MyEnumerable(int count)
        {
            for(var value = 0; value < count; value++)
                yield return value;
        }

        // [Params(0, 100, 10_000)]
        [Params(100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            range = Enumerable.Range(0, Count);
            rangeAsEnumerable = range;

            array = System.Linq.Enumerable.ToArray(range);
            arrayAsEnumerable = array;

            list = System.Linq.Enumerable.ToList(range);
            listAsEnumerable = list;

            enumerable = MyEnumerable(Count);
        }

        // [BenchmarkCategory("Array")]
        // [Benchmark(Baseline = true)]
        // public int Linq_Array() => 
        //     System.Linq.Enumerable.Count(array);

        // [BenchmarkCategory("List")]
        // [Benchmark(Baseline = true)]
        // public int Linq_List() => 
        //     System.Linq.Enumerable.Count(list);

        // [BenchmarkCategory("Range")]
        // [Benchmark(Baseline = true)]
        // public int Linq_Range() => 
        //     System.Linq.Enumerable.Count(range);

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable() => 
            System.Linq.Enumerable.Count(enumerable);

        // [BenchmarkCategory("Array")]
        // [Benchmark]
        // public int Linq_Array_AsEnumerable() => 
        //     System.Linq.Enumerable.Count(arrayAsEnumerable);

        // [BenchmarkCategory("List")]
        // [Benchmark]
        // public int Linq_List_AsEnumerable() => 
        //     System.Linq.Enumerable.Count(listAsEnumerable);

        // [BenchmarkCategory("Range")]
        // [Benchmark]
        // public int Linq_Range_AsEnumerable() => 
        //     System.Linq.Enumerable.Count(rangeAsEnumerable);

        // [BenchmarkCategory("Array")]
        // [Benchmark]
        // public int Hyperlinq_Array() => 
        //     array.Count();

        // [BenchmarkCategory("List")]
        // [Benchmark]
        // public int Hyperlinq_List() => 
        //     list.Count<List<int>, List<int>.Enumerator, int>();

        // [BenchmarkCategory("Range")]
        // [Benchmark]
        // public int Hyperlinq_Range() => 
        //     range.Count<Enumerable.RangeEnumerable, int>();

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable() => 
            enumerable.Count();

        // [BenchmarkCategory("Array")]
        // [Benchmark]
        // public int Hyperlinq_Array_AsEnumerable() => 
        //     arrayAsEnumerable.Count();

        // [BenchmarkCategory("List")]
        // [Benchmark]
        // public int Hyperlinq_List_AsEnumerable() => 
        //     listAsEnumerable.Count();

        // [BenchmarkCategory("Range")]
        // [Benchmark]
        // public int Hyperlinq_Range_AsEnumerable() => 
        //     rangeAsEnumerable.Count();
    }
}
