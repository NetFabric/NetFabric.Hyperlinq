using BenchmarkDotNet.Attributes;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class LambdaBenchmarks
    {
        readonly Predicate<int> predicate = item => item == 0;

        [Benchmark(Baseline = true)]
        public bool Lambda() 
            => MethodLambda(1, item => item == 1);

        [Benchmark]
        public bool Local()
            => MethodLocal(1, item => item == 1);

        bool MethodLocal(int value, Predicate<int> predicate)
        {
            return Method(value, Combine);

            bool Combine(int item)
                => this.predicate(item) && predicate(item);
        }

        bool MethodLambda(int value, Predicate<int> predicate)
            => Method(value, Combine(this.predicate, predicate));

        static Predicate<int> Combine(Predicate<int> predicate0, Predicate<int> predicate1)
                => item => predicate0(item) && predicate1(item);

        static bool Method(int value, Predicate<int> predicate)
            => predicate(value);
    }
}
