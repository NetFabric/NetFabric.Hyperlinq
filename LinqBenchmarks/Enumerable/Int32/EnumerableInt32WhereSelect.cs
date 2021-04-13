using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

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
                    sum += item * 3;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Where(item => item.IsEven()).Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.IEnumerableExtensionMethods.Where(source, item => item.IsEven()).Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqOptimizer()
        {
            var sum = 0;
            foreach (var item in source
                .AsQueryExpr()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .Run())
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Streams()
        {
            var sum = 0;
            foreach (var item in source
                .AsStream()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToEnumerable())
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
                .Select(item => item * 3))
                sum += item;
            return sum;
        }
        
        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var predicate = new Int32IsEven();
            var selector = new TripleOfInt32();
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
            foreach (var item in source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_IFunction()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>())
                sum += item;
            return sum;
        }
    }
}
