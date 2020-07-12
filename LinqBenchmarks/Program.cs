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
                typeof(ArraySkipTakeSelect),
                typeof(ArraySkipTakeWhere),
                typeof(ArrayWhere),
                typeof(ArrayWhereSelect),
                typeof(ArrayWhereSelectToArray),
                typeof(ArrayWhereSelectToList),
                typeof(ListSelect),
                typeof(ListWhere),
                typeof(ListSkipTakeSelect),
                typeof(ListSkipTakeWhere),
                typeof(ListWhereSelect),
                typeof(ListWhereSelectToArray),
                typeof(ListWhereSelectToList),
            });
            _ = switcher.Run(args);
        }
    }
}
