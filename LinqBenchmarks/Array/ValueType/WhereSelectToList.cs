using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{ 
    public class ArrayValueTypeWhereSelectToList: ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public List<FatValueType> ForLoop()
        {
            var list = new List<FatValueType>();
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly  var item = ref source[index];
                if (item.IsEven())
                    list.Add(item * 2);
            }
            return list;
        }

        [Benchmark]
        public List<FatValueType> ForeachLoop()
        {
            var list = new List<FatValueType>();
            foreach (var item in source)
            {
                if (item.IsEven())
                    list.Add(item * 2);
            }
            return list;
        }

        [Benchmark]
        public List<FatValueType> Linq()
            => Enumerable.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();

        [Benchmark]
        public List<FatValueType> LinqFaster()
            => new List<FatValueType>(JM.LinqFaster.LinqFaster.WhereSelectF(source, item => item.IsEven(), item => item * 2));

        [Benchmark]
        public List<FatValueType> StructLinq()
            => source.ToStructEnumerable().Where(item => item.IsEven(), x => x).Select(item => item * 2, x => x).ToList();

        [Benchmark]
        public List<FatValueType> StructLinq_IFunction()
        {
            var where = new FatValueTypeIsEven();
            var mult = new DoubleOfFatValueType();
            return source.ToRefStructEnumerable().Where(ref where, x => x).Select(ref mult, x => x, x => x).ToList();
        }

        [Benchmark]
        public List<FatValueType> Hyperlinq()
            => ArrayExtensions.Where(source, item => item.IsEven()).Select(item => item * 2).ToList();
    }
}
