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
            CountInterface(array, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Array_Class() => 
            CountArray(array, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Array_GenericConstraint() => 
            CountConstraint(array, _ => true);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Array_GenericConstraintWrapper() => 
            CountConstraintWrapper(array, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark(Baseline = true)]
        public int List_Interface() => 
            CountInterface(list, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_Class() => 
            CountList(list, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_GenericConstraint() => 
            CountConstraint(list, _ => true);

        [BenchmarkCategory("List")]
        [Benchmark]
        public int List_GenericConstraintWrapper() => 
            CountConstraintWrapper(list, _ => true);

        public static int CountInterface<TSource>(IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            var count = 0;
            for (var index = 0; index < source.Count; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int CountArray<TSource>(TSource[] source, Func<TSource, bool> predicate)
        {
            var count = 0;
            for (var index = 0; index < source.Length; index++)
            {
                 if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int CountList<TSource>(List<TSource> source, Func<TSource, bool> predicate)
        {
            var count = 0;
            for (var index = 0; index < source.Count; index++)
            {
                 if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static int CountConstraint<TSource>(TSource[] source, Func<TSource, bool> predicate)
            => Count<TSource[], TSource>(source, predicate);

        public static int CountConstraint<TSource>(List<TSource> source, Func<TSource, bool> predicate)
            => Count<List<TSource>, TSource>(source, predicate);

        public static int CountConstraintWrapper<TSource>(List<TSource> source, Func<TSource, bool> predicate)
            => Count<ListWrapper<TSource>, TSource>(new ListWrapper<TSource>(source), predicate);

        public static int CountConstraintWrapper<TSource>(TSource[] source, Func<TSource, bool> predicate)
            => Count<ArrayWrapper<TSource>, TSource>(new ArrayWrapper<TSource>(source), predicate);
        
        public static int Count<TEnumerable, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
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

            public int Count => array.Length;

            public TSource this[int index] => array[index];

            public List<TSource>.Enumerator GetEnumerator() => throw new NotSupportedException();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
        }

        public readonly struct ListWrapper<TSource> : IReadOnlyList<TSource>
        {
            readonly List<TSource> list;

            public ListWrapper(List<TSource> list)
            {
                this.list = list;
            }

            public int Count => list.Count;

            public TSource this[int index] => list[index];

            public List<TSource>.Enumerator GetEnumerator() => list.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => list.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
        }
    }
}
