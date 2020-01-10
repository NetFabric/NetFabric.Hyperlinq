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
    public class LinkedListBenchmarks
    {
        LinkedList<int> list;

        [Params(10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            list = new LinkedList<int>(ValueEnumerable.Range(0, Count));
        }

        [BenchmarkCategory("All")]
        [Benchmark(Baseline = true)]
        public bool Linq_All()
            => System.Linq.Enumerable.All(list, item => (item & 0x01) == 0);

        [BenchmarkCategory("All")]
        [Benchmark]
        public bool Hyperlinq_All()
            => list.All(item => (item & 0x01) == 0);

        [BenchmarkCategory("All")]
        [Benchmark]
        public bool Custom_All()
            => CustomAll(list, item => (item & 0x01) == 0);

        static bool CustomAll<TSource>(LinkedList<TSource> list, Predicate<TSource> predicate)
        {
            var current = list.First;
            while (current is object)
            {
                if (!predicate(current.Value))
                    return false;

                current = current.Next;
            }

            return true;
        }
    }
}
