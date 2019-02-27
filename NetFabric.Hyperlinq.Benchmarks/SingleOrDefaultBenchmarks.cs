using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SingleOrDefaultBenchmarks
    {
        int[] array;
        List<int> list;
        IEnumerable<int> linqRange;
        Enumerable.RangeEnumerable hyperlinqRange;
        IEnumerable<int> enumerableReference;
        TestEnumerable.Enumerable enumerableValue;

        [GlobalSetup]
        public void GlobalSetup()
        {
            linqRange = System.Linq.Enumerable.Range(0, 1);
            hyperlinqRange = Enumerable.Range(0, 1);
            array = hyperlinqRange.ToArray();
            list = hyperlinqRange.ToList();
            enumerableReference = TestEnumerable.ReferenceType(1);
            enumerableValue = TestEnumerable.ValueType(1);
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array_SingleOrDefault() => 
            System.Linq.Enumerable.SingleOrDefault(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List_SingleOrDefault() => 
            System.Linq.Enumerable.SingleOrDefault(list);

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range_SingleOrDefault() => 
            System.Linq.Enumerable.SingleOrDefault(linqRange);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference_SingleOrDefault() => 
            System.Linq.Enumerable.SingleOrDefault(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Linq_Enumerable_Value_SingleOrDefault() => 
            System.Linq.Enumerable.SingleOrDefault(enumerableValue);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_SingleOrDefault() => 
            array.SingleOrDefault();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int? Hyperlinq_Array_SingleOrNull() =>
            array.SingleOrNull();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List_SingleOrDefault() => 
            list.SingleOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int? Hyperlinq_List_SingleOrNull() =>
            list.SingleOrNull();

        [BenchmarkCategory("Range")]
        [Benchmark]

        public int Hyperlinq_Range_SingleOrDefault() =>
            hyperlinqRange.SingleOrDefault();

        [BenchmarkCategory("Range")]
        [Benchmark]

        public int? Hyperlinq_Range_SingleOrNull() =>
            hyperlinqRange.SingleOrNull();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference_SingleOrDefault() => 
            enumerableReference.SingleOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int? Hyperlinq_Enumerable_Reference_SingleOrNull() =>
            enumerableReference.SingleOrNull();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value_SingleOrDefault() => 
            enumerableValue.SingleOrDefault<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int? Hyperlinq_Enumerable_Value_SingleOrNull() =>
            enumerableValue.SingleOrNull<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>();
    }
}
