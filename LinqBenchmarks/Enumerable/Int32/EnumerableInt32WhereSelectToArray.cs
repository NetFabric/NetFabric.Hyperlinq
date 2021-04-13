using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.Enumerable.Int32
{
    public partial class EnumerableInt32WhereSelectToArray: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int[] ForeachLoop()
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                if (item.IsEven())
                    list.Add(item * 3);
            }
            return list.ToArray();
        }

        [Benchmark]
        public int[] Linq()
            => source.Where(item => item.IsEven()).Select(item => item * 3).ToArray();

        [Benchmark]
        public int[] LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods
                .Where(source, item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] LinqOptimizer()
            => source.AsQueryExpr()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArray()
                .Run();

        [Benchmark]
        public int[] Streams()
            => source.AsStream()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] StructLinq()
            => source.ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            var selector = new TripleOfInt32();
            return source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToArray(x => x);
        }

        [Benchmark]
        public int[] Hyperlinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] Hyperlinq_IFunction()
            => source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>()
                .ToArray();
    }
}
