using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Int32.Array
{
    public class Int32ArrayWhereSelect: BenchmarkBase
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
                if (item.IsEven())
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
                if (item.IsEven())
                    sum += item * 2;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(source, item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.WhereSelectF(source, item => item.IsEven(), item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var where = new IsEvenFunction();
            var mult = new DoubleFunction();
            foreach (var item in source.ToStructEnumerable().Where(ref where, x => x).Select(ref mult, x => x, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Where(source, item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }
    }
}
