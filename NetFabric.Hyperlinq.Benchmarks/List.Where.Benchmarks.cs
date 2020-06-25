using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using JM.LinqFaster;
using StructLinq;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MemoryDiagnoser]
    public class ListWhereBenchmarks
    {
        List<int> list; 

        [Params(0, 1, 10, 100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup() 
            => list = ValueEnumerable.Range(0, Count).ToList();

        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            for (var index = 0; index < list.Count; index++)
            {
                var item = list[index];
                if ((item & 0x01) == 0)
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int Linq_Where()
        {
            var sum = 0;
            foreach (var item in Enumerable.Where(list, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster_WhereF()
        {
            var items = LinqFaster.WhereF(list, item => (item & 0x01) == 0);
            var sum = 0;
            for (var index = 0; index < items.Count; index++)
                sum += items[index];
            return sum;
        }

        [Benchmark]
        public int StructLinq_Where()
        {
            var sum = 0;
            foreach (var item in list.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_Where()
        {
            var sum = 0;
            foreach (var item in ListBindings.Where(list, item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }
    }
}
