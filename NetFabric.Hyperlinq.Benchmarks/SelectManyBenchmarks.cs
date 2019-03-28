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

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        { 
            var count = 0;
            foreach(var item in System.Linq.Enumerable.SelectMany(linqRange, item => System.Linq.EnumerableEx.Return(item)))
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

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array() 
        { 
            var count = 0;
            foreach(var item in array.SelectMany<int, Enumerable.ReturnEnumerable<int>, Enumerable.ReturnEnumerable<int>.ValueEnumerator, int>(item => Enumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("List")]
        [Benchmark]
        public int Hyperlinq_List() 
        { 
            var count = 0;
            foreach(var item in list.SelectMany<int, Enumerable.ReturnEnumerable<int>, Enumerable.ReturnEnumerable<int>.ValueEnumerator, int>(item => Enumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
        { 
            var count = 0;
            foreach(var item in hyperlinqRange.SelectMany<Enumerable.ReturnEnumerable<int>, Enumerable.ReturnEnumerable<int>.ValueEnumerator, int>(item => Enumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        { 
            var count = 0;
            foreach(var item in enumerableReference.SelectMany<int, Enumerable.ReturnEnumerable<int>, Enumerable.ReturnEnumerable<int>.ValueEnumerator, int>(item => Enumerable.Return(item)))
                count++;
            return count;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        { 
            var count = 0;
            foreach(var item in enumerableValue.SelectMany<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int, Enumerable.ReturnEnumerable<int>, Enumerable.ReturnEnumerable<int>.ValueEnumerator, int>(item => Enumerable.Return(item)))
                count++;
            return count;
        }
    }
}
