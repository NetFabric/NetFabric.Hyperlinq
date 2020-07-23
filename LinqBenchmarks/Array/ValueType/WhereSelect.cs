using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeWhereSelect: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var sum = default(FatValueType);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (item.IsEven())
                    sum += item * 2;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var sum = default(FatValueType);
            foreach (var item in source)
            {
                if (item.IsEven())
                    sum += item * 2;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in Enumerable.Where(source, item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType LinqFaster()
        {
            var items = JM.LinqFaster.LinqFaster.WhereSelectF(source, item => item.IsEven(), item => item * 2);
            var sum = default(FatValueType);
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (var item in source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq_IFunction()
        {
            var sum = default(FatValueType);
            var predicate = new FatValueTypeIsEven();
            var selector = new DoubleOfFatValueType();
            foreach (var item in source.ToRefStructEnumerable().Where(ref predicate, x => x).Select(ref selector, x => x, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in ArrayExtensions.Where(source, item => item.IsEven()).Select(item => item * 2))
                sum += item;
            return sum;
        }
    }
}
