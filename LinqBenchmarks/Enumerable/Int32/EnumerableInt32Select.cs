using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32Select: EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += item * 2;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.IEnumerableExtensionMethods.Select(source, item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var selector = new DoubleOfInt32();
            foreach (var item in source.ToStructEnumerable().Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable().Select(item => item * 2))
                sum += item;
            return sum;
        }
    }
}
