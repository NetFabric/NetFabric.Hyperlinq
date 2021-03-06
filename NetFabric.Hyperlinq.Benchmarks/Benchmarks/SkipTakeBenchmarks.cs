using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class SkipTakeBenchmarks : RandomSkipBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var sum = 0;
            foreach (var item in array.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in enumerableValue.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in collectionValue.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_AsyncEnumerable_Value()
        {
            var sum = 0;
            await foreach (var item in asyncEnumerableValue.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark(Baseline = true)]
        public async ValueTask<int> Linq_AsyncEnumerable_Reference()
        {
            var sum = 0;
            await foreach (var item in asyncEnumerableReference.Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        // -------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Array()
        {
            var sum = 0;
            foreach (var item in array.ToStructEnumerable().Skip(Skip, x => x).Take(Count, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int StructLinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in enumerableValue.ToStructEnumerable().Skip(Skip, x => x).Take(Count, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int StructLinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in collectionValue.ToStructEnumerable().Skip(Skip, x => x).Take(Count, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int StructLinq_List_Value()
        {
            var sum = 0;
            foreach (var item in listValue.ToStructEnumerable().Skip(Skip, x => x).Take(Count, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int StructLinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.ToStructEnumerable().Skip(Skip, x => x).Take(Count, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int StructLinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.ToStructEnumerable().Skip(Skip, x => x).Take(Count, x => x))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int StructLinq_List_Reference()
        {
            var sum = 0;
            foreach (var item in listReference.ToStructEnumerable().Skip(Skip, x => x).Take(Count, x => x))
                sum += item;
            return sum;
        }

        // -------------------


        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_For()
        {
            var source = array.AsValueEnumerable().Skip(Skip).Take(Count);
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                sum += item;
            }

            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Array_Foreach()
        {
            var sum = 0;
            foreach (var item in array.AsValueEnumerable().Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span_For()
        {
            var source = array.AsSpan().AsValueEnumerable().Skip(Skip).Take(Count);
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span_Foreach()
        {
            var sum = 0;
            foreach (var item in array.AsSpan().AsValueEnumerable().Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory_For()
        {
            var source = memory.AsValueEnumerable().Skip(Skip).Take(Count);
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory_Foreach()
        {
            var sum = 0;
            foreach (var item in memory.AsValueEnumerable().Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Value()
        {
            var sum = 0;
            foreach (var item in enumerableValue.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public int Hyperlinq_Collection_Value()
        {
            var sum = 0;
            foreach (var item in collectionValue.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value_For()
        {
            var source = listValue.AsValueEnumerable().Skip(Skip).Take(Count);
            var sum = 0;
            for (var index = 0; index < Count; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public int Hyperlinq_List_Value_Foreach()
        {
            var sum = 0;
            foreach (var item in listValue.AsValueEnumerable().Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("AsyncEnumerable_Value")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Value()
        {
            var sum = 0;
            await foreach (var item in asyncEnumerableValue.AsAsyncValueEnumerable()
                .Skip(Skip)
                .Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public int Hyperlinq_Enumerable_Reference()
        {
            var sum = 0;
            foreach (var item in enumerableReference.AsValueEnumerable().Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public int Hyperlinq_Collection_Reference()
        {
            var sum = 0;
            foreach (var item in collectionReference.AsValueEnumerable().Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference_For()
        {
            var source = listReference.AsValueEnumerable().Skip(Skip).Take(Count);
            var sum = 0;
            for (var index = 0; index < Count; index++)
                sum += source[index];
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public int Hyperlinq_List_Reference_Foreach()
        {
            var sum = 0;
            foreach (var item in listReference.AsValueEnumerable().Skip(Skip).Take(Count))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("AsyncEnumerable_Reference")]
        [Benchmark]
        public async ValueTask<int> Hyperlinq_AsyncEnumerable_Reference()
        {
            var sum = 0;
            await foreach (var item in asyncEnumerableReference.AsAsyncValueEnumerable()
                .Skip(Skip)
                .Take(Count))
                sum += item;
            return sum;
        }
    }
}
