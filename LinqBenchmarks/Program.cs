using BenchmarkDotNet.Running;
using System;

namespace LinqBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                typeof(ArraySelectBenchmarks),
                typeof(ArrayWhereBenchmarks),
                typeof(ListSelectBenchmarks),
                typeof(ListWhereBenchmarks),
            });
            _ = switcher.Run(args);
        }
    }
}
