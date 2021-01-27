using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Enumerable.Int32
{
    public class EnumerableInt32SkipTakeSelect: EnumerableInt32SkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForeachLoop()
        {
            using var enumerator = source.GetEnumerator();
            for (var index = 0; index < Skip; index++)
                _ = enumerator.MoveNext();
            var sum = 0;
            for (var index = 0; index < Count; index++)
                sum += enumerator.Current * 2;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Skip(Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var sum = 0;
            foreach (var item in global::LinqAF.IEnumerableExtensionMethods.Skip(source, Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source
                .ToStructEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var selector = new DoubleOfInt32();
            foreach (var item in source
                .ToStructEnumerable()
                .Skip(Skip, x=> x)
                .Take(Count, x=>x)
                .Select(ref selector, x=> x, x=>x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable().Skip(Skip).Take(Count).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Foreach_IFunction()
        {
            var sum = 0;
            foreach (var item in source.AsValueEnumerable().Skip(Skip).Take(Count).Select<int, DoubleOfInt32>())
                sum += item;
            return sum;
        }
    }
}
