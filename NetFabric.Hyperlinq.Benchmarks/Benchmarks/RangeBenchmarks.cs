using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class RangeBenchmarks : CountBenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Range_Async")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_Range_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int StructLinq_Range()
        {
            var sum = 0;
            foreach (var item in StructEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Range_Async")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_Range_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncValueEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

    }
}