using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Int32.Array
{
    public class Int32ArrayWhereSelectToList: BenchmarkBase
    {
        int[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Count).ToArray();

        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    list.Add(item * 2);
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
                    list.Add(item * 2);
            }
            return list;
        }

        [Benchmark]
        public List<int> Linq()
            => Enumerable.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new List<int>(JM.LinqFaster.LinqFaster.WhereSelectF(source, item => item.IsEven(), item => item * 2));

        [Benchmark]
        public List<int> StructLinq()
            => source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item * 2, x => x).ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var where = new IsEvenFunction();
            var mult = new DoubleFunction();
            return source.ToStructEnumerable().Where(ref where, x => x).Select(ref mult, x => x, x => x).ToList();
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => ArrayExtensions.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();
    }
}
