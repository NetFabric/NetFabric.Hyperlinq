using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32WhereCount: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
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
        public int LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods.Count(source, item => item.IsEven());

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
