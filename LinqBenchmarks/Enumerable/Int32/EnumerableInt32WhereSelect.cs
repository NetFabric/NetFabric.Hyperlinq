using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32WhereSelect: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
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
            foreach (var item in source.Where(item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.IEnumerableExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source
                .ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var predicate = new Int32IsEven();
            var selector = new DoubleOfInt32();
            foreach (var item in source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable().Where(item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_IFunction()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable().Where<Int32IsEven>(new Int32IsEven()).Select<int, DoubleOfInt32>())
                sum += item;
            return sum;
        }
    }
}
