using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks
{
    public class ArrayWhereSelect : BenchmarkBase
    {
        int[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Count).ToArray();

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if ((item & 0x01) == 0)
                    sum += item * 2;
            }
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
            {
                if ((item & 0x01) == 0)
                    sum += item * 2;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(source, item => (item & 0x01) == 0).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.WhereSelectF(source, item => (item & 0x01) == 0, item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x).Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var where = new WhereFunction();
            var mult = new Mult();
            foreach (var item in source.ToStructEnumerable().Where(ref where, x => x).Select(ref mult, x => x, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Where(source, item => (item & 0x01) == 0).Select(item => item * 2))
                sum += item;
            return sum;
        }

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
