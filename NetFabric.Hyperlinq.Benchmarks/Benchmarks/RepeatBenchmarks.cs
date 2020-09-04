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
        [Benchmark]
        public int Linq_Repeat()
        {
            var sum = 0;
            using (var enumerator = EnumerableEx.Repeat(1).GetEnumerator())
            {
                for (var counter = Count; counter != 0; counter--)
                {
                    _ = enumerator.MoveNext();
                    sum += enumerator.Current;
                }
            }
            return sum;
        }

        [BenchmarkCategory("Repeat_Count")]
        [Benchmark(Baseline = true)]
        public int Linq_Repeat_Count() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Repeat_Async")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_Repeat_Async() 
        {
            var sum = 0;
            await foreach(var item in AsyncEnumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        //[BenchmarkCategory("Repeat")]
        //[Benchmark]
        //public int Hyperlinq_Repeat()
        //{
        //    var sum = 0;
        //    var enumerator = ValueEnumerable.Repeat(1).GetEnumerator();
        //    for (var counter = Count; counter != 0; counter--)
        //    {
        //        _ = enumerator.MoveNext();
        //        sum += enumerator.Current;
        //    }
        //    return sum;
        //}

        [BenchmarkCategory("Repeat_Count")]
        [Benchmark]
        public int Hyperlinq_Repeat_Count() 
        {
            var sum = 0;
            foreach(var item in ValueEnumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Repeat_Async")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_Repeat_Async() 
        {
            var sum = 0;
            await foreach(var item in AsyncValueEnumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }
    }
}