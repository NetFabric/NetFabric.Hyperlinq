using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ForCanBeConvertedToForeach

namespace NetFabric.Hyperlinq.Benchmarks.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class ListIterationBenchmarks
    {
        const int seed = 2982;
        List<int> list;
        ImmutableList<int> immutableList;

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var source = Utils.GetRandomValues(seed, Count);
            list = new List<int>(source);
            immutableList = ImmutableList.Create(source);
        }

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int List_Enumerable()
        {
            var sum = 0;
            foreach (var item in list)
                sum += item;
            return sum;
        }
        
        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_Indexer()
        {
            var source = list;
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }
        
        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_Span()
        {
            var sum = 0;
            foreach (var item in CollectionsMarshal.AsSpan(list))
                sum += item;
            return sum;
        }
        

        [BenchmarkCategory("ImmutableList")]
        [Benchmark(Baseline = true)]
        public int ImmutableList_Enumerable()
        {
            var sum = 0;
            foreach (var item in immutableList)
                sum += item;
            return sum;
        }
        
        [BenchmarkCategory("ImmutableList")]
        [Benchmark]
        public int ImmutableList_Indexer()
        {
            var source = immutableList;
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }
    }
}
