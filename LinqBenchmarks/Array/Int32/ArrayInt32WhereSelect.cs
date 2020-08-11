using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32WhereSelect: ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
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
            foreach (var item in System.Linq.Enumerable.Where(source, item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = source.WhereSelectF(item => item.IsEven(), item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.ArrayExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 2))
                sum += item;
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
            var predicate = new Int32IsEven();
            var selector = new DoubleOfInt32();
            foreach (var item in source.ToStructEnumerable().Where(ref predicate, x => x).Select(ref selector, x => x, x => x))
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
