using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace NetFabric.Hyperlinq.Rewriter.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                    typeof(QueryBenchmarks),
                });
            switcher.Run(args);        
        }
    }
}
