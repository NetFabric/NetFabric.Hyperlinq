using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    public class ToArrayVsToListBenchmarks
    {

        [Params(1, 10, 100, 1000, 10000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public int[] Linq_Range_Where_ToArray() =>
            System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Where(System.Linq.Enumerable.Range(0, Count), _ => true));

        [Benchmark]
        public List<int> Linq_Range_Where_ToList() =>
            System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(System.Linq.Enumerable.Range(0, Count), _ => true));

        [Benchmark]
        public int[] Hyperlinq_Range_Where_ToArray() =>
            ValueEnumerable.Range(0, Count).Where(_ => true).ToArray();

        [Benchmark]
        public List<int> Hyperlinq_Range_Where_ToList() =>
            ValueEnumerable.Range(0, Count).Where(_ => true).ToList();
    }
}
