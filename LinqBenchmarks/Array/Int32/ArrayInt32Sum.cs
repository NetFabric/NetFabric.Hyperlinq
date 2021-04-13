using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32Sum: ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
            => source.Sum();

        [Benchmark]
        public int LinqFaster()
            => source.SumF();

        [Benchmark]
        public int LinqFaster_SIMD()
            => source.SumS();

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Sum(source);

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
        {
            return source
                .ToStructEnumerable()
                .Sum(x => x);
        }

        [Benchmark]
        public int Hyperlinq()
            => source
                .AsValueEnumerable()
                .Sum();
    }
}
