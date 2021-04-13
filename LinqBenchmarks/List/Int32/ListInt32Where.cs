using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.List.Int32
{
    public class ListInt32Where: Int32ListBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
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
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(source, item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = source.WhereF(item => item.IsEven());
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.ListExtensionMethods.Where(source, item => item.IsEven()))
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
                .Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var predicate = new Int32IsEven();
            foreach (var item in source
                .ToStructEnumerable()
                .Where(ref predicate, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable()
                .Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_IFunction()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable()
                .Where<Int32IsEven>())
                sum += item;
            return sum;
        }
    }
}
