using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using JM.LinqFaster;
using StructLinq;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    //[SimpleJob(RuntimeMoniker.Net461, baseline: true)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp21)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereCountBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.Count(array, item => (item & 0x01) == 0);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.Count(enumerableValue, item => (item & 0x01) == 0);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value() =>
            System.Linq.Enumerable.Count(collectionValue, item => (item & 0x01) == 0);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value() =>
            System.Linq.Enumerable.Count(listValue, item => (item & 0x01) == 0);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() =>
            System.Linq.Enumerable.Count(enumerableReference, item => (item & 0x01) == 0);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference() =>
            System.Linq.Enumerable.Count(collectionReference, item => (item & 0x01) == 0);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference() =>
            System.Linq.Enumerable.Count(listReference, item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int LinqFaster_CountF() =>
            LinqFaster.CountF(array, item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Count() =>
            array.ToStructEnumerable().Where(item => (item & 0x01) == 0, x => x).Count(x => x);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinqFaster_Count()
        {
            var where = new WhereFunction();
            var count = array.ToStructEnumerable().Where(ref where, x => x).Count(x => x);
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() =>
            array.Where(item => (item & 0x01) == 0).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span() =>
            array.AsSpan().Where(item => (item & 0x01) == 0).Count();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory() =>
            memory.Where(item => (item & 0x01) == 0).Count();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() =>
            EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .Where(item => (item & 0x01) == 0).Count();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value() =>
            ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .Where(item => (item & 0x01) == 0).Count();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value() =>
            ReadOnlyListExtensions.AsValueEnumerable<int>(listValue)
            .Where(item => (item & 0x01) == 0).Count();


        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .Where(item => (item & 0x01) == 0).Count();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .Where(item => (item & 0x01) == 0).Count();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .Where(item => (item & 0x01) == 0).Count();
    }
}
