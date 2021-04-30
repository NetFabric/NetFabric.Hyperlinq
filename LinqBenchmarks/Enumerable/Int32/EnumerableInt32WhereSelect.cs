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
            var items = source
                .Where(item => item.IsEven())
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var items = global::LinqAF.IEnumerableExtensionMethods
                .Where(source, item => item.IsEven())
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqOptimizer()
        {
            var items = source
                .AsQueryExpr()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .Run();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Streams()
        {
            var items = source
                .AsStream()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToEnumerable();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var items = source.ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
        
        [Benchmark]
        public int StructLinq_ValueDelegate()
        {
            var predicate = new Int32IsEven();
            var selector = new TripleOfInt32();
            var items = source.ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var items = source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_ValueDelegate()
        {
            var items = source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}
