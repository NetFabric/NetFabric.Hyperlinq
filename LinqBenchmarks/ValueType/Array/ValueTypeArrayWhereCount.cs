using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.ValueType.Array
{
    public class ArrayWhereCount : BenchmarkBase
    {
        int[] source;

        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Count).ToArray();

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var count = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (item.IsEven())
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
                if (item.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
        public int Linq()
            => Enumerable.Count(source, item => item.IsEven());

        [Benchmark]
        public int LinqFaster()
            => JM.LinqFaster.LinqFaster.CountF(source, item => item.IsEven());

        [Benchmark]
        public int StructLinq()
            => source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Count();

        [Benchmark]
        public int StructLinq_IFunction()
        {
            var where = new IsEvenFunction();
            return source.ToStructEnumerable().Where(ref where, x => x).Count();
        }

        [Benchmark]
        public int Hyperlinq()
            => ArrayExtensions.Where(source, item => item.IsEven()).Count();
    }
}
