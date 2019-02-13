using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class WhereSelectForEachBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(array, _ => true), item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(list, _ => true), item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(linqRange, _ => true), item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(enumerable, _ => true), item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
        { 
            var count = 0;
            foreach(var item in array.Where(_ => true).Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
        { 
            var count = 0;
            foreach(var item in list.Where(_ => true).Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
        { 
            var count = 0;
            foreach(var item in hyperlinqRange.Where(_ => true).Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable()
        { 
            var count = 0;
            foreach(var item in enumerable.Where(_ => true).Select(item => item))
                count++;
            return count;
        }
    }
}
