using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class WhereSelectCountBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
            => array.Where(item => (item & 0x01) == 0).Select(item => item).Count();


        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        
            => enumerableValue.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
            => collectionValue.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
            => listValue.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Value()
            => asyncEnumerableValue.Where(item => (item & 0x01) == 0).Select(item => item).CountAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        
            => enumerableReference.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
            => collectionReference.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
            => listReference.Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public ValueTask<int> Linq_AsyncEnumerable_Reference()
            => asyncEnumerableReference.Where(item => (item & 0x01) == 0).Select(item => item).CountAsync();

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array()
            => array.AsValueEnumerable().Where(item => (item & 0x01) == 0).Select(item => item).Count();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
            => enumerableValue.AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .Select(item => item)
                .Count();

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
            => collectionValue.AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .Select(item => item)
                .Count();

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value()
        
            => listValue
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .Select(item => item)
                .Count();

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
            => asyncEnumerableValue
                .AsAsyncValueEnumerable()
                .Where((item, _) => new ValueTask<bool>((item & 0x01) == 0))
                .Select((item, _) => new ValueTask<int>(item))
                .CountAsync();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
            => enumerableReference
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .Select(item => item)
                .Count();

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
            => collectionReference  
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .Select(item => item)
                .Count();

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference()
            => listReference
                .AsValueEnumerable()
                .Where(item => (item & 0x01) == 0)
                .Select(item => item)
                .Count();

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
            => asyncEnumerableReference
                .AsAsyncValueEnumerable()
                .Where((item, _) => new ValueTask<bool>((item & 0x01) == 0))
                .Select((item, _) => new ValueTask<int>(item))
                .CountAsync();
    }
}
