using BenchmarkDotNet.Attributes;
using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace LinqBenchmarks.Array.Int32
{
    public class ArrayInt32SelectToList: ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public List<int> ForLoop()
        {
            var list = new List<int>();
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                list.Add(item * 2);
            }
            return list;
        }

        [Benchmark]
        public List<int> ForeachLoop()
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                list.Add(item * 2);
            }
            return list;
        }

        [Benchmark]
        public List<int> Linq()
            => System.Linq.Enumerable
                .Select(source, item => item * 2)
                .ToList();

        [Benchmark]
        public List<int> LinqFaster()
            => new List<int>(source.SelectF(item => item * 2));

        [Benchmark]
        public List<int> LinqFaster_SIMD()
            => new List<int>(source.SelectS(item => item * 2, item => item * 2));

        [Benchmark]
        public List<int> LinqAF()
            => global::LinqAF.ArrayExtensionMethods
                .Select(source, item => item * 2)
                .ToList();

        [Benchmark]
        public List<int> StructLinq()
            => source.ToStructEnumerable()
                .Select(item => item * 2)
                .ToList();

        [Benchmark]
        public List<int> StructLinq_IFunction()
        {
            var selector = new DoubleOfInt32();
            return source.ToStructEnumerable()
                .Select(ref selector, x => x, x => x)
                .ToList();
        }

        [Benchmark]
        public List<int> Hyperlinq()
            => source.AsValueEnumerable()
                .Select(item => item * 2)
                .ToList();

        [Benchmark]
        public List<int> Hyperlinq_IFunction()
           => source.AsValueEnumerable()
                .Select<int, DoubleOfInt32>()
                .ToList();

        [Benchmark]
        public List<int> Hyperlinq_SIMD()
            => source.AsValueEnumerable()
                .SelectVector(item => item * 2, item => item * 2)
                .ToList();

        [Benchmark]
        public List<int> Hyperlinq_IFunction_SIMD()
           => source.AsValueEnumerable()
                .SelectVector<int, int, DoubleOfInt32, DoubleOfInt32>()
                .ToList();
    }
}
