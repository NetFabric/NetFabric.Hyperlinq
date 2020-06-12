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
            var sum = 0;
            foreach(var item in System.Linq.ImmutableArrayExtensions.Where(array, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Select")]
        [Benchmark(Baseline = true)]
        public int Select()
        {
            var sum = 0;
            foreach (var item in System.Linq.ImmutableArrayExtensions.Select(array, item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Where")]
        [Benchmark]
        public int WhereHyper()
        {
            var sum = 0;
            foreach (var item in ReadOnlyListExtensions.Where<ImmutableArray<int>, int>(array, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Select")]
        [Benchmark]
        public int SelectHyper()
        {
            var source = ReadOnlyListExtensions.Select<ImmutableArray<int>, int, int>(array, item => item);
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
            return sum;
        }
    }
}
