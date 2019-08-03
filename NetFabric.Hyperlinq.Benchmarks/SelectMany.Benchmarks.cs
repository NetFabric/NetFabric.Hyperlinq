using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SelectManyBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.SelectMany(linqRange, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Queue")]
        [Benchmark(Baseline = true)]
        public int Linq_Queue() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.SelectMany(queue, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.SelectMany(array, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int Linq_List() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.SelectMany(list, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.SelectMany(enumerableReference, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()       
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.SelectMany(enumerableValue, item => System.Linq.EnumerableEx.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
        { 
            var count = 0;
            foreach(var item in hyperlinqRange.SelectMany<ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.Enumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Queue")]
        [Benchmark]
        public int Hyperlinq_Queue() 
        { 
            var count = 0;
            foreach(var item in queue.SelectMany<int, ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.Enumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
        { 
            var count = 0;
            foreach(var item in array.SelectMany<int, ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.Enumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
        { 
            var count = 0;
            foreach(var item in list.SelectMany<int, ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.Enumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        { 
            var count = 0;
            foreach(var item in enumerableReference.AsValueEnumerable().SelectMany<ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.Enumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()        
        { 
            var count = 0;
            foreach(var item in enumerableValue.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>().SelectMany<ValueEnumerable.ReturnEnumerable<int>, ValueEnumerable.ReturnEnumerable<int>.Enumerator, int>(item => ValueEnumerable.Return(item)))
                count++;
            return count;
        }
    }
}
