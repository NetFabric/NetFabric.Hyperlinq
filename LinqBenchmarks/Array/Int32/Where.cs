using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32Where: ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    sum += item;
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
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(source, item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.WhereF(source, item => item.IsEven());
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Where(item => item.IsEven(), x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var predicate = new Int32IsEven();
            foreach (var item in source.ToStructEnumerable().Where(ref predicate, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Where(source, item => item.IsEven()))
                sum += item;
            return sum;
        }
    }
}
