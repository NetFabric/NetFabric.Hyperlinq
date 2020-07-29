using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.ValueType
{
    public class ArrayValueTypeDistinct: BenchmarkBase
    {
        FatValueType[] source;

        [Params(4)]
        public int Duplicates { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => source = System.Linq.Enumerable
                .SelectMany(
                    System.Linq.Enumerable.Range(0, Duplicates), 
                    _ => System.Linq.Enumerable.Range(0, Count)
                        .Select(value => new FatValueType(value)))
                .ToArray();

        [Benchmark(Baseline = true)]
        public FatValueType ForLoop()
        {
            var set = new HashSet<FatValueType>();
            var sum = default(FatValueType);
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType ForeachLoop()
        {
            var set = new HashSet<FatValueType>();
            var sum = default(FatValueType);
            foreach (var item in source)
            {
                if (set.Add(item))
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public FatValueType Linq()
        {
            var sum = default(FatValueType);
            foreach (var item in System.Linq.Enumerable.Distinct(source))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType StructLinq()
        {
            var sum = default(FatValueType);
            foreach (ref readonly  var item in source.ToRefStructEnumerable().Distinct(x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public FatValueType Hyperlinq()
        {
            var sum = default(FatValueType);
            foreach (var item in ArrayExtensions.Distinct(source))
                sum += item;
            return sum;
        }
    }
}
