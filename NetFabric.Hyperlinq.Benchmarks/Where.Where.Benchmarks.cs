using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereWhereBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(linqRange, _ => true), _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("LinkedList")]
        [Benchmark(Baseline = true)]
        public int Linq_LinkedList()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(linkedList, _ => true), _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(array, _ => true), _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(list, _ => true), _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(enumerableReference, _ => true), _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(System.Linq.Enumerable.Where(enumerableValue, _ => true), _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range()
        {
            var count = 0;
            foreach (var item in hyperlinqRange.Where(_ => true).Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("LinkedList")]
        [Benchmark]
        public int Hyperlinq_LinkedList()
        {
            var count = 0;
            foreach (var item in linkedList.Where(_ => true).Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var count = 0;
            foreach (var item in array.Where(_ => true).Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List()
        {
            var count = 0;
            foreach (var item in list.Where(_ => true).Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in enumerableReference
                .AsValueEnumerable()
                .Where(_ => true)
                .Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in enumerableValue
                .AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerable => enumerable.GetEnumerator())
                .Where(_ => true)
                .Where(_ => true))
                count++;
            return count;
        }
    }
}
