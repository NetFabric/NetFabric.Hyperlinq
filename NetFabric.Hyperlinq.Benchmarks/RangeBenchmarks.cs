using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    public class RangeBenchmarks
    {
        [Params(0, 100, 10_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        {
            var sum = 0;
            foreach(var item in System.Linq.Enumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Range() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Range(0, Count))
                sum += item;
            return sum;
        }    
    }
}