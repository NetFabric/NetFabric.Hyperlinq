using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using JM.LinqFaster;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(array, _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(enumerableValue, _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(collectionValue, _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(listValue, _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(enumerableReference, _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(collectionReference, _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var count = 0;
            foreach (var item in System.Linq.Enumerable.Where(listReference, _ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_Array()
        {
            var count = 0;
            foreach (var item in array.WhereF(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
        {
            var count = 0;
            foreach (var item in array.Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator()).Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator()).Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        {
            var count = 0;
            foreach (var item in Enumerable.AsValueEnumerable<TestList.Enumerable, TestList.Enumerable.Enumerator, int>(listValue, enumerable => enumerable.GetEnumerator()).Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var count = 0;
            foreach (var item in enumerableReference.AsValueEnumerable().Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var count = 0;
            foreach (var item in collectionReference.AsValueEnumerable().Where(_ => true))
                count++;
            return count;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
        {
            var count = 0;
            foreach (var item in listReference.AsValueEnumerable().Where(_ => true))
                count++;
            return count;
        }
    }
}
