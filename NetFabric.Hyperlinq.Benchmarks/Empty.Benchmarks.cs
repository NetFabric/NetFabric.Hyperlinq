using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class EmptyBenchmarks
    {
        [BenchmarkCategory("Empty()")]
        [Benchmark(Baseline = true)]
        public int Linq_Empty_ForEach() 
        {
            var sum = 0;
            foreach(var item in System.Linq.Enumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty()")]
        [Benchmark]
        public int Hyperlinq_Empty_ForEach()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty()")]
        [Benchmark]
        public int Hyperlinq_Empty_For()
        {
            var source = ValueEnumerable.Empty<int>();
            var sum = 0;
            for (var index = 0; index < source.Count(); index++)
                sum += source[index];
            return sum;
        }

        [BenchmarkCategory("Empty().Count()")]
        [Benchmark(Baseline = true)]
        public int Linq_Empty_Count()
            => System.Linq.Enumerable.Count(System.Linq.Enumerable.Empty<int>());

        [BenchmarkCategory("Empty().Count()")]
        [Benchmark]
        public int Hyperlinq_Empty_Count()
            => ValueEnumerable.Empty<int>().Count();

        [BenchmarkCategory("Empty().Select()")]
        [Benchmark(Baseline = true)]
        public int Linq_Empty_Select_ForEach()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Select(System.Linq.Enumerable.Empty<int>(), item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty().Select()")]
        [Benchmark]
        public int Hyperlinq_Empty_Select_ForEach()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Empty<int>().Select(item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty().Select()")]
        [Benchmark]
        public int Hyperlinq_Empty_Select_For()
        {
            var source = ValueEnumerable.Empty<int>().Select(item => item);
            var sum = 0;
            for (var index = 0; index < source.Count(); index++)
                sum += source[index];
            return sum;
        }

        [BenchmarkCategory("Empty().Where()")]
        [Benchmark(Baseline = true)]
        public int Linq_Empty_Where_ForEach()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Empty<int>(), item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty().Where()")]
        [Benchmark]
        public int Hyperlinq_Empty_Where_ForEach()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Empty<int>().Where(item => (item & 0x01) == 0))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty().Where().Select()")]
        [Benchmark(Baseline = true)]
        public int Linq_Empty_Where_Select_ForEach()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(System.Linq.Enumerable.Empty<int>(), item => (item & 0x01) == 0), item => item))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty().Where().Select()")]
        [Benchmark]
        public int Hyperlinq_Empty_Where_Select_ForEach()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Empty<int>().Where(item => (item & 0x01) == 0).Select(item => item))
                sum += item;
            return sum;
        }
    }
}