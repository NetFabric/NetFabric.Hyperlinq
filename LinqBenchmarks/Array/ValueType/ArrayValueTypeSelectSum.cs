using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeSelectSum: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                sum += item.Value0;
            }
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
            {
                sum += item.Value0;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
            => System.Linq.Enumerable.Sum(source, item => item.Value0);

        [Benchmark]
        public int LinqFaster()
            => source.SumF(item => item.Value0);

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Sum(source, item => item.Value0);

        [Benchmark]
        public int LinqOptimizer()
            => source
                .AsQueryExpr()
                .Select(item => item.Value0)
                .Sum()
                .Run();

        [Benchmark]
        public int Streams()
            => source
                .AsStream()
                .Select(item => item.Value0)
                .Sum();

        [Benchmark]
        public int StructLinq()
            => source
                .ToRefStructEnumerable()
                .Sum((in FatValueType item) => item.Value0);

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var selector = new Value0Selector();
            return source
                .ToRefStructEnumerable()
                .Sum(ref selector, x => x, x => x);
        }

        [Benchmark]
        public int Hyperlinq()
            => source.AsValueEnumerable()
                .Select(item => item.Value0)
                .Sum();

        [Benchmark]
        public int Hyperlinq_IFunction()
            => source.AsValueEnumerable()
                .Select<int, Value0Selector>()
                .Sum();
    }
}
