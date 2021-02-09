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
    public class RepeatBenchmarks : CountBenchmarksBase
    {

        [BenchmarkCategory("Repeat")]
        [Benchmark(Baseline = true)]
        public int Linq() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Repeat_Async")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_Async() 
        {
            var sum = 0;
            await foreach(var item in AsyncEnumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in StructEnumerable.Repeat(1, (uint)Count))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int Hyperlinq() 
        {
            var sum = 0;
            foreach(var item in ValueEnumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Repeat_Async")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_Async() 
        {
            var sum = 0;
            await foreach(var item in AsyncValueEnumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }
    }
}