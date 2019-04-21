using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class LambdaBenchmarks
    {
        Func<int, bool> predicate0 = item => item == 0;
        Func<int, bool> predicate1 = item => item == 1;

        [Benchmark(Baseline = true)]
        public bool Lambda() 
            => Method(1, CombinePredicates(predicate0, predicate1));

        [Benchmark]
        public bool Local() 
        {
            return Method(1, CombinePredicates);

            bool CombinePredicates(int item) 
                => predicate0(item) && predicate1(item);
        }

        static bool Method(int value, Func<int, bool> predicate)
            => predicate(value);

        static Func<int, bool> CombinePredicates(Func<int, bool> predicate0, Func<int, bool> predicate1) 
                => item => predicate0(item) && predicate1(item);

    }
}
