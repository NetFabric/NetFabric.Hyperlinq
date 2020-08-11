using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32Where: EnumerableInt32BenchmarkBase
    {
        [BenchmarkCategory("Enumerable", "Int32")]
        [Benchmark(Baseline = true)]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.IEnumerableExtensionMethods.Where(source, item => item.IsEven()))
                sum += item;
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
            foreach (var item in source.AsValueEnumerable().Where(item => item.IsEven()))
                sum += item;
            return sum;
        }
    }
}
