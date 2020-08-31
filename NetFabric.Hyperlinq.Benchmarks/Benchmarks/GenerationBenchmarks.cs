using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class GenerationOperationsBenchmarks : CountBenchmarksBase
    {
        [BenchmarkCategory("Empty")]
        [Benchmark(Baseline = true)]
        public int Linq_Empty()
        {
            var sum = 0;
            foreach (var item in Enumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty_Async")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_Empty_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Range")]
        [Benchmark(Baseline = true)]
        public int Linq_Range() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Range_Async")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_Range_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int Linq_Repeat()
        {
            var sum = 0;
            using (var enumerator = EnumerableEx.Repeat(1).GetEnumerator())
            {
                for (var counter = Count; counter != 0; counter--)
                {
                    _ = enumerator.MoveNext();
                    sum += enumerator.Current;
                }
            }
            return sum;
        }

        [BenchmarkCategory("Repeat_Count")]
        [Benchmark(Baseline = true)]
        public int Linq_Repeat_Count() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Return")]
        [Benchmark(Baseline = true)]
        public int Linq_Return()
        {
            var sum = 0;
            foreach (var item in EnumerableEx.Return(1))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Create")]
        [Benchmark(Baseline = true)]
        public int Linq_Create() 
        {
            var sum = 0;
            foreach(var item in EnumerableEx.Create(() => new Enumerator(1, Count)))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int StructLinq_Range()
        {
            var sum = 0;
            foreach (var item in StructEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        // ---------------------------------------------------------------------

        [BenchmarkCategory("Empty")]
        [Benchmark]
        public int Hyperlinq_Empty()
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Empty_Async")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_Empty_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncValueEnumerable.Empty<int>())
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range() 
        {
            var sum = 0;
            foreach (var item in ValueEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Range_Async")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_Range_Async()
        {
            var sum = 0;
            await foreach (var item in AsyncValueEnumerable.Range(0, Count))
                sum += item;
            return sum;
        }

        //[BenchmarkCategory("Repeat")]
        //[Benchmark]
        //public int Hyperlinq_Repeat()
        //{
        //    var sum = 0;
        //    var enumerator = ValueEnumerable.Repeat(1).GetEnumerator();
        //    for (var counter = Count; counter != 0; counter--)
        //    {
        //        _ = enumerator.MoveNext();
        //        sum += enumerator.Current;
        //    }
        //    return sum;
        //}

        [BenchmarkCategory("Repeat_Count")]
        [Benchmark]
        public int Hyperlinq_Repeat_Count() 
        {
            var sum = 0;
            foreach(var item in ValueEnumerable.Repeat(1, Count))
                sum += item;
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