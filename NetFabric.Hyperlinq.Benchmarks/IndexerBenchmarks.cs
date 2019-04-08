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
            list = new List<int>(Count);
        }

        [Benchmark(Baseline = true)]
        public int Enumerator() => 
            CountEnumerable<List<int>, List<int>.Enumerator, int>(list, _ => true);

        [Benchmark]
        public int Indexer() => 
            CountList<List<int>, int>(list, _ => true);

        static int CountEnumerable<TEnumerable, TEnumerator, TSource>(List<int> source, Func<int, bool> predicate)
        {
            var count = 0;
            using(var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;
        }        

        public static int CountList<TEnumerable, TSource>(List<int> source, Func<int, bool> predicate)
        {
            var sourceCount = source.Count;
            if (sourceCount == 0) return 0;

            var count = 0;
            for (var index = 0; index < sourceCount; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }
    }
}
