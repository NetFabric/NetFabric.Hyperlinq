using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks
{
    public class ListWhereSelectToArray : BenchmarkBase
    {
        List<int> source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Count).ToList();

        [Benchmark(Baseline = true)]
        public int[] ForLoop()
        {
            var list = new List<int>();
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if ((item & 0x01) == 0)
                    list.Add(item * 2);
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
                if ((item & 0x01) == 0)
                    list.Add(item * 2);
            }
            return list.ToArray();
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int[] Linq()
            => Enumerable.Where(source, item => (item & 0x01) == 0).Select(item => item * 2).ToArray();

        [Benchmark]
        public int[] LinqFaster()
            => JM.LinqFaster.LinqFaster.WhereSelectF(source, item => (item & 0x01) == 0, item => item * 2).ToArray();

        [Benchmark]
        public int[] StructLinq()
            => source.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x).Select(item => item * 2, x => x).ToArray();

        [Benchmark]
        public int[] StructLinq_IFunction()
        {
            var where = new WhereFunction();
            var mult = new Mult();
            return source.ToStructEnumerable().Where(ref where, x => x).Select(ref mult, x => x, x => x).ToArray();
        }

        [Benchmark]
        public int[] Hyperlinq()
            => ListBindings.Where(source, item => (item & 0x01) == 0).Select(item => item * 2).ToArray();

        struct WhereFunction: IFunction<int, bool>
        {
            public bool Eval(int element) 
                => (element & 0x01) == 0;
        }

        struct Mult: IFunction<int, int>
        {
            public int Eval(int element)
                => element * 2;
        }
    }
}
