using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class SelectForEachBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(array, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(list, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(linqRange, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(enumerable, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
        { 
            var count = 0;
            foreach(var item in array.Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
        { 
            var count = 0;
            foreach(var item in list.Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
        { 
            var count = 0;
            foreach(var item in hyperlinqRange.Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable")]
        [Benchmark]
        public int Hyperlinq_Enumerable()
        { 
            var count = 0;
            foreach(var item in enumerable.Select(item => item))
                count++;
            return count;
        }
    }
}
