using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace NetFabric.Hyperlinq
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class VirtualCallBenchmarks
    {
        int[] array;
        List<int> list;

        [Params(10_000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = ValueEnumerable.Range(0, Size).ToArray();
            list = ValueEnumerable.Range(0, Size).ToList();
        }

        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Array_Interface() => 
            CountInterface(array, item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Array_Class() => 
            CountArray(array, item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Array_GenericConstraint() => 
            CountConstraint(array, item => (item & 0x01) == 0);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Array_GenericConstraintWrapper() => 
            CountConstraintWrapper(array, item => (item & 0x01) == 0);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int List_Interface() => 
            CountInterface(list, item => (item & 0x01) == 0);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_Class() => 
            CountList(list, item => (item & 0x01) == 0);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_GenericConstraint() => 
            CountConstraint(list, item => (item & 0x01) == 0);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_GenericConstraintWrapper() => 
            CountConstraintWrapper(list, item => (item & 0x01) == 0);

        public static int CountInterface<TSource>(IReadOnlyList<TSource> source, Predicate<TSource> predicate)
        {
            var count = 0;
            for (var index = 0; index < source.Count; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int CountArray<TSource>(TSource[] source, Predicate<TSource> predicate)
        {
            var count = 0;
            for (var index = 0; index < source.Length; index++)
            {
                 if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int CountList<TSource>(List<TSource> source, Predicate<TSource> predicate)
        {
            var count = 0;
            for (var index = 0; index < source.Count; index++)
            {
                 if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int CountConstraint<TSource>(TSource[] source, Predicate<TSource> predicate)
            => Count<TSource[], TSource>(source, predicate);

        public static int CountConstraint<TSource>(List<TSource> source, Predicate<TSource> predicate)
            => Count<List<TSource>, TSource>(source, predicate);

        public static int CountConstraintWrapper<TSource>(List<TSource> source, Predicate<TSource> predicate)
            => Count<ListWrapper<TSource>, TSource>(new ListWrapper<TSource>(source), predicate);

        public static int CountConstraintWrapper<TSource>(TSource[] source, Predicate<TSource> predicate)
            => Count<ArrayWrapper<TSource>, TSource>(new ArrayWrapper<TSource>(source), predicate);
        
        public static int Count<TEnumerable, TSource>(TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IReadOnlyList<TSource>
        {
            var count = 0;
            for (var index = 0; index < source.Count; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public readonly struct ArrayWrapper<TSource> : IReadOnlyList<TSource>
        {
            readonly TSource[] array;

            public ArrayWrapper(TSource[] array)
            {
                this.array = array;
            }

            public readonly int Count => array.Length;

            public readonly TSource this[int index] => array[index];

            public readonly List<TSource>.Enumerator GetEnumerator() => throw new NotSupportedException();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
            readonly IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
        }

        public readonly struct ListWrapper<TSource> : IReadOnlyList<TSource>
        {
            readonly List<TSource> list;

            public ListWrapper(List<TSource> list)
            {
                this.list = list;
            }

            public readonly int Count => list.Count;

            public readonly TSource this[int index] => list[index];

            public readonly List<TSource>.Enumerator GetEnumerator() => list.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => list.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
        }
    }
}
