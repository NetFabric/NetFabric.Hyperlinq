using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace NetFabric.Hyperlinq.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                    typeof(GenerationOperationsBenchmarks),
                    typeof(CountBenchmarks),
                    typeof(SelectForEachBenchmarks),
                    typeof(SelectCountBenchmarks),
                    typeof(WhereForEachBenchmarks),
                    typeof(WhereSelectCountBenchmarks),
                    typeof(CachingBenchmarks),
                });
            switcher.Run(args);        
        }
    }
}
