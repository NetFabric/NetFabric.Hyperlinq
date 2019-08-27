using BenchmarkDotNet.Attributes;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class LambdaBenchmarks
    {
        readonly Func<int, bool> predicate = item => item == 0;

        [Benchmark(Baseline = true)]
        public bool Lambda() 
            => MethodLambda(1, item => item == 1);

        [Benchmark]
        public bool Local()
            => MethodLocal(1, item => item == 1);

        bool MethodLocal(int value, Func<int, bool> predicate)
        {
            return Method(value, CombinePredicates);

            bool CombinePredicates(int item)
                => this.predicate(item) && predicate(item);
        }

        bool MethodLambda(int value, Func<int, bool> predicate)
            => Method(value, CombinePredicates(this.predicate, predicate));

        static Func<int, bool> CombinePredicates(Func<int, bool> predicate0, Func<int, bool> predicate1)
                => item => predicate0(item) && predicate1(item);

        static bool Method(int value, Func<int, bool> predicate)
            => predicate(value);
    }
}
