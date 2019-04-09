using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SelectBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(linqRange, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(queue, item => item))
                count++;
            return count;
        }

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

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(enumerableReference, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()        
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.Select(enumerableValue, item => item))
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

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue() 
        { 
            var count = 0;
            foreach(var item in queue.Select(item => item))
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

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        { 
            var count = 0;
            foreach(var item in enumerableReference.Select(item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()        
        { 
            var count = 0;
            foreach(var item in enumerableValue.Select(item => item))
                count++;
            return count;
        }
    }
}
