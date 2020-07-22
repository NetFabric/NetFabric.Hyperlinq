using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeWhereCount: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var count = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (item.Value0.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var count = 0;
            foreach (var item in source)
            {
                if (item.Value0.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
        public int Linq()
            => Enumerable.Count(source, item => item.Value0.IsEven());

        [Benchmark]
        public int LinqFaster()
            => JM.LinqFaster.LinqFaster.CountF(source, item => item.Value0.IsEven());

        [Benchmark]
        public int StructLinq()
            => source.ToStructEnumerable().Where(item => item.Value0.IsEven(), x => x).Count();

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var where = new FatValueTypeIsEven();
            return source.ToRefStructEnumerable().Where(ref where, x => x).Count();
        }

        [Benchmark]
        public int Hyperlinq()
            => ArrayExtensions.Where(source, item => item.Value0.IsEven()).Count();
    }
}
