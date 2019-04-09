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
        Queue<int> queue;
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
            queue = new Queue<int>(linqRange);
            array = hyperlinqRange.ToArray();
            list = hyperlinqRange.ToList();
            enumerableReference = TestEnumerable.ReferenceType(1);
            enumerableValue = TestEnumerable.ValueType(1);
        }

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() => 
            System.Linq.Enumerable.SingleOrDefault(linqRange);

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue() => 
            System.Linq.Enumerable.SingleOrDefault(queue);

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() => 
            System.Linq.Enumerable.SingleOrDefault(array);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() => 
            System.Linq.Enumerable.SingleOrDefault(list);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.SingleOrDefault(enumerableReference);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() => 
            System.Linq.Enumerable.SingleOrDefault(enumerableValue);

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() =>
            hyperlinqRange.SingleOrDefault();

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue() =>
            queue.SingleOrDefault();

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() => 
            array.SingleOrDefault();

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() => 
            list.SingleOrDefault();

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference() => 
            enumerableReference.SingleOrDefault();

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value() => 
            enumerableValue.SingleOrDefault();
    }
}
