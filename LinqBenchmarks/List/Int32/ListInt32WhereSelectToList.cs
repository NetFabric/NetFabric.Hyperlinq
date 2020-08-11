using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.List.Int32
{
    public class ListInt32WhereSelectToList: Int32ListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    list.Add(item * 2);
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
                    list.Add(item * 2);
            }
            return list;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public List<int> Linq()
            => System.Linq.Enumerable.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new List<int>(source.WhereSelectF(item => item.IsEven(), item => item * 2));

        [Benchmark]
        public List<int> LinqAF()
            => global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();

        [Benchmark]
        public List<int> StructLinq()
            => source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item * 2, x => x).ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            var selector = new DoubleOfInt32();
            return source.ToStructEnumerable().Where(ref predicate, x => x).Select(ref selector, x => x, x => x).ToList();
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => ListBindings.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();
    }
}
