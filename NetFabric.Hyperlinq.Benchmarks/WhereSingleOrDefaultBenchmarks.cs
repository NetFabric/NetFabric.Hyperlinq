using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class WhereSingleOrDefaultBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_SingleOrDefault()
            => System.Linq.Enumerable.Where(array, value => value == 0).SingleOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List_SingleOrDefault()
            => System.Linq.Enumerable.Where(list, value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range_SingleOrDefault()
            => System.Linq.Enumerable.Where(linqRange, value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference_SingleOrDefault()
            => System.Linq.Enumerable.Where(enumerableReference, value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value_SingleOrDefault()
            => System.Linq.Enumerable.Where(enumerableValue, value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_SingleOrDefault()
            => array.Where(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int? Hyperlinq_Array_SingleOrNull()
            => array.Where(value => value == 0).SingleOrNull();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List_SingleOrDefault()
            => list.Where(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int? Hyperlinq_List_SingleOrNull()
            => list.Where(value => value == 0).SingleOrNull();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_SingleOrDefault()
            => hyperlinqRange.Where(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int? Hyperlinq_Range_SingleOrNull()
            => hyperlinqRange.Where(value => value == 0).SingleOrNull();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference_SingleOrDefault()
            => enumerableReference.Where(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int? Hyperlinq_Enumerable_Reference_SingleOrNull()
            => enumerableReference.Where(value => value == 0).SingleOrNull();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value_SingleOrDefault()
            => enumerableValue.Where<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(value => value == 0).SingleOrDefault();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int? Hyperlinq_Enumerable_Value_SingleOrNull()
            => enumerableValue.Where<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(value => value == 0).SingleOrNull();
    }
}
