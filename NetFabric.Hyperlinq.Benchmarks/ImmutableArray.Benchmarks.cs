using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ImmutableArrayBenchmarks
    {
        ImmutableArray<int> array;

        [Params(0, 10, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var range = ValueEnumerable.Range(0, Count);
            array = ImmutableArray.CreateRange(range);
        }

        [BenchmarkCategory("Where")]
        [Benchmark(Baseline = true)]
        public int Where()
        { 
            var count = 0;
            foreach(var item in System.Linq.ImmutableArrayExtensions.Where(array, item => (item & 0x01) == 0))
                count++;
            return count;
        }

        [BenchmarkCategory("Select")]
        [Benchmark(Baseline = true)]
        public int Select()
        {
            var count = 0;
            foreach (var item in System.Linq.ImmutableArrayExtensions.Select(array, item => item))
                count++;
            return count;
        }

        [BenchmarkCategory("Where")]
        [Benchmark]
        public int WhereHyper()
        {
            var count = 0;
            foreach (var item in ReadOnlyList.Where<ImmutableArray<int>, int>(array, item => (item & 0x01) == 0))
                count++;
            return count;
        }

        [BenchmarkCategory("Select")]
        [Benchmark]
        public int SelectHyper()
        {
            var count = 0;
            foreach (var item in ReadOnlyList.Select<ImmutableArray<int>, int, int>(array, item => item))
                count++;
            return count;
        }
    }
}
