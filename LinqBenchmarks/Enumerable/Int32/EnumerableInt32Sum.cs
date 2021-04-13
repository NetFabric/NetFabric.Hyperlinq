using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32Sum: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Linq()
            => source.Sum();

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods.Sum(source);

        [Benchmark]
        public int LinqOptimizer()
            => source
                .AsQueryExpr()
                .Sum()
                .Run();

        [Benchmark]
        public int Streams()
            => source
                .AsStream()
                .Sum();

        [Benchmark]
        public int StructLinq()
            => source
                .ToStructEnumerable()
                .Sum();

        [Benchmark]
        public int StructLinq_IFunction()
            => source
                .ToStructEnumerable()
                .Sum(x => x);

        [Benchmark]
        public int Hyperlinq()
            => source
                .AsValueEnumerable()
                .Sum();
    }
}
