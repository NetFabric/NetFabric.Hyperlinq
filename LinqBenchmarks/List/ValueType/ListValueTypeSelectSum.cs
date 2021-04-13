using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.List.ValueType
{
    public class ListValueTypeSelectSum: ValueTypeListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
                sum += source[index].Value0;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += item.Value0;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Linq()
            => System.Linq.Enumerable.Sum(source, item => item.Value0);

        [Benchmark]
        public int LinqFaster()
            => source.SumF(item => item.Value0);

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ListExtensionMethods.Sum(source, item => item.Value0);

        [Benchmark]
        public int LinqOptimizer()
            => source.AsQueryExpr()
                .Select(x => x.Value0)
                .Sum()
                .Run();

        [Benchmark]
        public int Streams()
            => source.AsStream()
                .Select(x => x.Value0)
                .Sum();

        [Benchmark]
        public int StructLinq()
            => source.ToRefStructEnumerable()
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
