using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;
using Nessos.LinqOptimizer.CSharp;
using Nessos.Streams.CSharp;

namespace LinqBenchmarks.ImmutableArray.Int32
{
    public class ImmutableArrayInt32Select: ImmutableArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
                sum += array[index] * 3;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += item * 3;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqOptimizer()
        {
            var sum = 0;
            foreach (var item in source.AsQueryExpr().Select(item => item * 3).Run())
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Streams()
        {
            var sum = 0;
            foreach (var item in source.AsStream().Select(item => item * 3).ToEnumerable())
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var selector = new TripleOfInt32();
            foreach (var item in source.ToStructEnumerable().Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable()
                .Select(item => item * 3))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_IFunction_Foreach()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable()
                .Select<int, TripleOfInt32>())
                sum += item;
            return sum;
        }

#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Hyperlinq_For()
        {
            var items = source.AsValueEnumerable()
                .Select(item => item * 3);
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_IFunction_For()
        {
            var items = source.AsValueEnumerable()
                .Select<int, TripleOfInt32>();
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

    }
}
