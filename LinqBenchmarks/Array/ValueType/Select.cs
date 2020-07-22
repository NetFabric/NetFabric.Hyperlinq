using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeSelect: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Length; index++)
                sum += new FatValueType(source[index].Value0 * 2).Value0;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += new FatValueType(item.Value0 * 2).Value0;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Select(source, item => new FatValueType(item.Value0 * 2)))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.SelectF(source, item => new FatValueType(item.Value0 * 2));
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index].Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Select(item => new FatValueType(item.Value0 * 2), x => x))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var mult = new DoubleOfFatValueType();
            foreach (var item in source.ToRefStructEnumerable().Select(ref mult, x => x, x => x))
                sum += item.Value0;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [Benchmark]
        public int Hyperlinq_Foreach()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Select(source, item => new FatValueType(item.Value0 * 2)))
                sum += item.Value0;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [Benchmark]
        public int Hyperlinq_For()
        {
            var items = ArrayExtensions.Select(source, item => new FatValueType(item.Value0 * 2));
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index].Value0;
            return sum;
        }
    }
}
