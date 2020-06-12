using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class GenerationOperationsBenchmarks
    {
        [Params(10_000)]
        public int Count { get; set; }

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        {
            var sum = 0;
            foreach(var item in System.Linq.Enumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Repeat")]
        [Benchmark(Baseline = true)]
        public int Linq_Repeat() 
        {
            var sum = 0;
            foreach(var item in System.Linq.Enumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }    

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int Ix_Repeat() 
        {
            var sum = 0;
            using(var enumerator = System.Linq.EnumerableEx.Repeat(1).GetEnumerator())
            {
                for(var counter = Count; counter != 0; counter--)
                {
                    _ = enumerator.MoveNext();
                    sum += enumerator.Current;
                }
            }
            return sum;
        }

        [BenchmarkCategory("Return")]
        [Benchmark(Baseline = true)]
        public int Ix_Return()
        {
            var sum = 0;
            foreach (var item in System.Linq.EnumerableEx.Return(1))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Create")]
        [Benchmark(Baseline = true)]
        public int Ix_Create() 
        {
            var sum = 0;
            foreach(var item in System.Linq.EnumerableEx.Create(() => new Enumerator(1, Count)))
                sum += item;
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_ForEach() 
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }    

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int Hyperlinq_Repeat_ForEach() 
        {
            var sum = 0;
            foreach(var item in ValueEnumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_For() 
        {
            var enumerable = ValueEnumerable.Range(0, Count);
            var sum = 0;
            for(var index = 0; index < enumerable.Count; index++)
                sum += enumerable[index];
            return sum;
        }    

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int Hyperlinq_Repeat_For() 
        {
            var enumerable = ValueEnumerable.Repeat(1, Count);
            var sum = 0;
            for(var index = 0; index < enumerable.Count; index++)
                sum += enumerable[index];
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Return")]
        [Benchmark]
        public int Hyperlinq_Return()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Return(1))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Create")]
        [Benchmark]
        public int Hyperlinq_Create()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Create<Enumerator, int>(() => new Enumerator(1, Count)))
                sum += item;
            return sum;
        }

        struct Enumerator : IEnumerator<int>
        {
            int counter;

            public Enumerator(int value, int count)
            {
                Current = value;
                counter = count;
            }

            public int Current { get; private set; }
            readonly object IEnumerator.Current 
                => Current;

            public bool MoveNext() => counter-- > 0;

            public readonly void Reset() => throw new NotSupportedException();

            public readonly void Dispose() { }
        }

    }
}