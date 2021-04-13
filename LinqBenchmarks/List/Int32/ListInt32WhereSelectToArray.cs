using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.List.Int32
{
    public partial class ListInt32WhereSelectToArray: Int32ListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int[] ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    list.Add(item * 3);
            }
            return list.ToArray();
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
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
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int[] Linq()
            => System.Linq.Enumerable
                .Where(source, item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] LinqFaster()
            => source
                .WhereSelectF(item => item.IsEven(), item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] LinqAF()
            => global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3).ToArray();

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
