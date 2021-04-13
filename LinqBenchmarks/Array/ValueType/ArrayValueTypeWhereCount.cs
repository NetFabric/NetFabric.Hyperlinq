using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;
using NetFabric.Hyperlinq;
using StructLinq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeWhereCount: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var count = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                if (item.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var count = 0;
            foreach (var item in source)
            {
                if (item.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
        public int Linq()
            => System.Linq.Enumerable.Count(source, item => item.IsEven());

        [Benchmark]
        public int LinqFaster()
            => source.CountF(item => item.IsEven());

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Count(source, item => item.IsEven());

        [Benchmark]
        public int StructLinq()
            => source
                .ToRefStructEnumerable()
                .Where((in FatValueType item) => item.IsEven())
                .Count();

        [Benchmark]
        public int LinqOptimizer()
            => source
                .AsQueryExpr()
                .Where(item => item.IsEven())
                .Count()
                .Run();

        [Benchmark]
        public int Streams()
            => source
                .AsStream()
                .Where(item => item.IsEven())
                .Count();

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var predicate = new FatValueTypeIsEven();
            return source
                .ToRefStructEnumerable()
                .Where(ref predicate, x => x)
                .Count(x=> x);
        }

        [Benchmark]
        public int Hyperlinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Count();

        [Benchmark]
        public int Hyperlinq_IFunction()
            => source.AsValueEnumerable()
                .Where<FatValueTypeIsEven>()
                .Count();
    }
}
