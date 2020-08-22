using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32WhereSelectToList: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
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

        [Benchmark]
        public List<int> Linq()
            => source.Where(item => item.IsEven()).Select(item => item * 2).ToList();

        [Benchmark]
        public List<int> LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();

        [Benchmark]
        public List<int> StructLinq()
            => source
                .ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 2)
                .ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            var selector = new DoubleOfInt32();
            return source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToList(x=>x);
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => source.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item * 2).ToList();
    }
}
