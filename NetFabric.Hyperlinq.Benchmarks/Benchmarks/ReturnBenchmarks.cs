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
    public class ReturnBenchmarks : BenchmarksBase
    {
        public override void GlobalSetup() { }

        [BenchmarkCategory("Return")]
        [Benchmark(Baseline = true)]
        public int Linq_Return()
        {
            var sum = 0;
            foreach (var item in EnumerableEx.Return(1))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Return_Async")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_Return_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerableEx.Return(1))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Return")]
        [Benchmark]
        public int Hyperlinq_Return()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Return(1))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Return_Async")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_Return_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncValueEnumerable.Return(1))
                sum += item;
            return sum;
        }
    }
}