using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.Array.Int32
{
    public partial class ArrayInt32WhereSelectToList: ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                if (item.IsEven())
                    list.Add(item * 3);
            }
            return list;
        }

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

        [Benchmark]
        public List<int> Linq()
            => source.Where(item => item.IsEven()).Select(item => item * 3).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new(source.WhereSelectF(item => item.IsEven(), item => item * 3));

        [Benchmark]
        public List<int> LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3).ToList();

        [Benchmark]
        public List<int> LinqOptimizer()
            => source.AsQueryExpr()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToList()
                .Run();

        [Benchmark]
        public List<int> Streams()
            => source.AsStream()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> StructLinq()
            => source.ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            var selector = new TripleOfInt32();
            return source.ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToList(x => x);
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3).ToList();

        [Benchmark]
        public List<int> Hyperlinq_IFunction()
            => source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>().ToList();
    }
}
