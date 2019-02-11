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
                    typeof(EmptyBenchmarks),
                    typeof(CountBenchmarks),
                    typeof(SelectForEachBenchmarks),
                    typeof(SelectCountBenchmarks),
                    typeof(WhereForEachBenchmarks),
                    typeof(WhereCountBenchmarks),
                    typeof(WhereSelectCountBenchmarks),
                    typeof(ToArrayBenchmarks),
                    typeof(ToListBenchmarks),
                    typeof(SelectToArrayBenchmarks),
                    typeof(SelectToListBenchmarks),
                    typeof(WhereToArrayBenchmarks),
                    typeof(WhereToListBenchmarks),
                });
            switcher.Run(args);        
        }
    }
}
