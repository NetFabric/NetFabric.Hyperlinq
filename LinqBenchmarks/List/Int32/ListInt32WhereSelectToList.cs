using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.List.Int32
{
    public partial class ListInt32WhereSelectToList : Int32ListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    list.Add(item * 3);
            }
            return list;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public List<int> ForeachLoop()
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                if (item.IsEven())
                    list.Add(item * 3);
            }
            return list;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public List<int> Linq()
            => System.Linq.Enumerable.Where(source, item => item.IsEven()).Select(item => item * 3).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new(source.WhereSelectF(item => item.IsEven(), item => item * 3));

        [Benchmark]
        public List<int> LinqAF()
            => global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3).ToList();

        [Benchmark]
        public List<int> LinqOptimizer()
            => source
                .AsQueryExpr()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToList()
                .Run();

        [Benchmark]
        public List<int> Streams()
            => source
                .AsStream()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> StructLinq()
            => source
                .ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            var selector = new TripleOfInt32();
            return source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToList(x => x);
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> Hyperlinq_IFunction()
            => source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>()
                .ToList();
    }
}
