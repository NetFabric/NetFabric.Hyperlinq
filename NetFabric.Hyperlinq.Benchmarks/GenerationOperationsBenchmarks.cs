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
        [Params(0, 100, 10_000)]
        //[Params(100)]
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

        [BenchmarkCategory("RepeatInfinitely")]
        [Benchmark(Baseline = true)]
        public int Ix_Repeat() 
        {
            var sum = 0;
            using(var enumerator = System.Linq.EnumerableEx.Repeat(1).GetEnumerator())
            {
                for(var counter = Count; counter != 0; counter--)
                {
                    enumerator.MoveNext();
                    sum += enumerator.Current;
                }
            }
            return sum;
        } 

        [BenchmarkCategory("Create")]
        [Benchmark(Baseline = true)]
        public int Ix_Create() 
        {
            var sum = 0;
            foreach(var item in System.Linq.EnumerableEx.Create(GetIEnumerator))
                sum += item;
            return sum;
        } 

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_ForEach() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Range(0, Count))
                sum += item;
            return sum;
        }    

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int Hyperlinq_Repeat_ForEach() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Repeat(1, Count))
                sum += item;
            return sum;
        }    

        [BenchmarkCategory("RepeatInfinitely")]
        [Benchmark]
        public int Hyperlinq_RepeatInfinitely_ForEach() 
        {
            var sum = 0;
            using(var enumerator = Enumerable.Repeat(1).GetEnumerator())
            {
                for(var counter = Count; counter != 0; counter--)
                {
                    enumerator.MoveNext();
                    sum += enumerator.Current;
                }
            }
            return sum;
        }    

        [BenchmarkCategory("Create")]
        [Benchmark]
        public int Hyperlinq_Create_ForEach() 
        {
            var sum = 0;
            foreach(var item in Enumerable.Create<Enumerator, int>(GetEnumerator))
                sum += item;
            return sum;
        } 

        [BenchmarkCategory("Range")]
        [Benchmark]
        public int Hyperlinq_Range_For() 
        {
            var enumerable = Enumerable.Range(0, Count);
            var sum = 0;
            for(var index = 0; index < enumerable.Count; index++)
                sum += enumerable[index];
            return sum;
        }    

        [BenchmarkCategory("Repeat")]
        [Benchmark]
        public int Hyperlinq_Repeat_For() 
        {
            var enumerable = Enumerable.Repeat(1, Count);
            var sum = 0;
            for(var index = 0; index < enumerable.Count; index++)
                sum += enumerable[index];
            return sum;
        }    

        [BenchmarkCategory("RepeatInfinitely")]
        [Benchmark]
        public int Hyperlinq_RepeatInfinitely_For() 
        {
            var enumerable = Enumerable.Repeat(1);
            var sum = 0;
            for(var index = 0; index < Count; index++)
                sum += enumerable[index];
            return sum;
        }    

        IEnumerator<int> GetIEnumerator() => new Enumerator(1, Count);
        Enumerator GetEnumerator() => new Enumerator(1, Count);

        struct Enumerator : IEnumerator<int>
        {
            readonly int value;
            int counter;

            public Enumerator(int value, int count)
            {
                this.value = value;
                this.counter = count;
            }

            public int Current => value;
            object IEnumerator.Current => value;

            public bool MoveNext() => counter-- > 0;

            public void Reset() => throw new NotSupportedException();

            public void Dispose() { }
        }

    }
}