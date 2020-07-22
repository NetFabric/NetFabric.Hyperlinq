using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeWhere: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (item.Value0.IsEven())
                    sum += item.Value0;
            }
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
            {
                if (item.Value0.IsEven())
                    sum += item.Value0;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(source, item => item.Value0.IsEven()))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.WhereF(source, item => item.Value0.IsEven());
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index].Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var sum = 0;
            foreach (var item in source.ToStructEnumerable().Where(item => item.Value0.IsEven(), x => x))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var sum = 0;
            var where = new FatValueTypeIsEven();
            foreach (var item in source.ToRefStructEnumerable().Where(ref where, x => x))
                sum += item.Value0;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var sum = 0;
            foreach (ref var item in ArrayExtensions.WhereRef(source, item => item.Value0.IsEven()))
                sum += item.Value0;
            return sum;
        }
    }
}
