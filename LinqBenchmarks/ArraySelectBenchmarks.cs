using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks
{
    [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ArraySelectBenchmarks
    {
        int[] array;

        [Params(0, 1, 10, 1_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
            => array = Enumerable.Range(0, Count).ToArray();

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < array.Length; index++)
                sum += array[index] * 2;
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in array)
                sum += item * 2;
            return sum;
        }

        [Benchmark]
        public int Linq_Select()
        {
            var sum = 0;
            foreach (var item in Enumerable.Select(array, item => item * 2))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster_SelectF()
        {
            var items = LinqFaster.SelectF(array, item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int StructLinq_Select()
        {
            var sum = 0;
            foreach (var item in array.ToStructEnumerable().Select(item => item * 2, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinqFaster_Select()
        {
            var sum = 0;
            var mult = new Mult();
            foreach (var item in array.ToStructEnumerable().Select(ref mult, x => x, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Select()
        {
            var items = ArrayExtensions.Select(array, item => item * 2);
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        struct Mult: IFunction<int, int>
        {
            public int Eval(int element) 
                => element * 2;
        }
    }
}
