using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MarkdownExporterAttribute.GitHub]
    public class IndexerBenchmarks
    {
        List<int> list;

        [Params(0, 100, 10_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            list = ValueEnumerable.Range(0, Count).ToList();
        }

        [Benchmark(Baseline = true)]
        public bool Enumerator() => 
            AllEnumerable(list, _ => true);

        [Benchmark]
        public bool Indexer() => 
            AllIndexer(list, _ => true);

        [Benchmark]
        public bool Hyperlinq() => 
            list.All(_ => true);

        static bool AllEnumerable<TSource>(List<TSource> source, Func<TSource, bool> predicate)
        {
            foreach(var item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }        

        static bool AllIndexer<TSource>(List<TSource> source, Func<TSource, bool> predicate)
        {
            var sourceCount = source.Count;
            for (var index = 0; index < sourceCount; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }
    }
}
