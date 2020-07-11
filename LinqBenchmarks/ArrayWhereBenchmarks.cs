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
    public class ArrayWhereBenchmarks
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
            {
                var item = array[index];
                if ((item & 0x01) == 0)
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in array)
            {
                if ((item & 0x01) == 0)
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int Linq_Where()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(array, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster_WhereF()
        {
            var items = LinqFaster.WhereF(array, item => (item & 0x01) == 0);
            var sum = 0;
            for (var index = 0; index < items.Length; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int StructLinq_Where()
        {
            var sum = 0;
            foreach (var item in array.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinqFaster_Where()
        {
            var sum = 0;
            var where = new WhereFunction();
            foreach (var item in array.ToStructEnumerable().Where(ref where, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Where()
        {
            var sum = 0;
            foreach (var item in ArrayExtensions.Where(array, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        struct WhereFunction: IFunction<int, bool>
        {
            public bool Eval(int element) 
                => (element & 0x01) == 0;
        }
    }
}
