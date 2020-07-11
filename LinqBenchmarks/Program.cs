using BenchmarkDotNet.Running;
using System;

namespace LinqBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                typeof(ArraySelect),
                typeof(ArrayWhere),
                typeof(ArrayWhereSelect),
                typeof(ArrayWhereSelectToArray),
                typeof(ArrayWhereSelectToList),
                typeof(ListSelect),
                typeof(ListWhere),
                typeof(ListWhereSelect),
                typeof(ListWhereSelectToArray),
                typeof(ListWhereSelectToList),
            });
            _ = switcher.Run(args);
        }
    }
}
