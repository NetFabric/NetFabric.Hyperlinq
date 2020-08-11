using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32WhereCount: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForeachLoop()
        {
            var count = 0;
            foreach (var item in source)
            {
                if (item.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
        public int Linq()
            => source.Count(item => item.IsEven());

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods.Count(source, item => item.IsEven());

        [Benchmark]
        public int StructLinq()
            => source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Count();

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var predicate = new Int32IsEven();
            return source.ToStructEnumerable().Where(ref predicate, x => x).Count();
        }

        [Benchmark]
        public int Hyperlinq()
            => source.AsValueEnumerable().Where(item => item.IsEven()).Count();
    }
}
