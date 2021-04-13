using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32WhereCount: ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var count = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
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
            => source.Count(item => item.IsEven());

        [Benchmark]
        public int LinqFaster()
            => source.CountF(item => item.IsEven());

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Count(source, item => item.IsEven());

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
        public int StructLinq()
            => source
                .ToStructEnumerable()
                .Where(item => item.IsEven())
                .Count();

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            return source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Count(x => x);
        }

        [Benchmark]
        public int Hyperlinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Count();

        [Benchmark]
        public int Hyperlinq_IFunction()
            => source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Count();
    }
}
