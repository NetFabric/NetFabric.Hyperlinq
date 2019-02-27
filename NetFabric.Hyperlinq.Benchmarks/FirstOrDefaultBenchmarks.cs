using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class FirstOrDefaultBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_FirstOrDefault() => 
            System.Linq.Enumerable.FirstOrDefault(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List_FirstOrDefault() => 
            System.Linq.Enumerable.FirstOrDefault(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range_FirstOrDefault() => 
            System.Linq.Enumerable.FirstOrDefault(linqRange);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference_FirstOrDefault() => 
            System.Linq.Enumerable.FirstOrDefault(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Linq_Enumerable_Value_FirstOrDefault() => 
            System.Linq.Enumerable.FirstOrDefault(enumerableValue);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_FirstOrDefault() => 
            array.FirstOrDefault();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int? Hyperlinq_Array_FirstOrNull() =>
            array.FirstOrNull();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List_FirstOrDefault() => 
            list.FirstOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int? Hyperlinq_List_FirstOrNull() =>
            list.FirstOrNull();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_FirstOrDefault() =>
            hyperlinqRange.FirstOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int? Hyperlinq_Range_FirstOrNull() =>
            hyperlinqRange.FirstOrNull();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference_FirstOrDefault() => 
            enumerableReference.FirstOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int? Hyperlinq_Enumerable_Reference_FirstOrNull() =>
            enumerableReference.FirstOrNull();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value_FirstOrDefault() => 
            enumerableValue.FirstOrDefault<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int? Hyperlinq_Enumerable_Value_FirstOrNull() =>
            enumerableValue.FirstOrNull<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();
    }
}
