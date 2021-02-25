using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using StructLinq;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class SelectBenchmarks : RandomBenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array()
        {
            var sum = 0;
            foreach (var item in System.Linq.Enumerable.Select(array, item => item))
                sum += item;
            return sum;
        }

        //[BenchmarkCategory("Enumerable_Value")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Enumerable_Value()
        //{
        //    var sum = 0;
        //    foreach (var item in System.Linq.Enumerable.Select(enumerableValue, item => item))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("Collection_Value")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Collection_Value()
        //{
        //    var sum = 0;
        //    foreach (var item in System.Linq.Enumerable.Select(collectionValue, item => item))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("List_Value")]
        //[Benchmark(Baseline = true)]
        //public int Linq_List_Value()
        //{
        //    var sum = 0;
        //    foreach (var item in System.Linq.Enumerable.Select(listValue, item => item))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("Enumerable_Reference")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Enumerable_Reference()
        //{
        //    var sum = 0;
        //    foreach (var item in System.Linq.Enumerable.Select(enumerableReference, item => item))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("Collection_Reference")]
        //[Benchmark(Baseline = true)]
        //public int Linq_Collection_Reference()
        //{
        //    var sum = 0;
        //    foreach (var item in System.Linq.Enumerable.Select(collectionReference, item => item))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("List_Reference")]
        //[Benchmark(Baseline = true)]
        //public int Linq_List_Reference()
        //{
        //    var sum = 0;
        //    foreach (var item in System.Linq.Enumerable.Select(listReference, item => item))
        //        sum += item;
        //    return sum;
        //}

        // -------------------

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int StructLinq_Array()
        {
            var sum = 0;
            foreach (var item in array.ToStructEnumerable().Select(item => item, x => x))
                sum += item;
            return sum;
        }

        //[BenchmarkCategory("Enumerable_Value")]
        //[Benchmark]
        //public int StructLinq_Enumerable_Value()
        //{
        //    var sum = 0;
        //    foreach (var item in enumerableValue.ToStructEnumerable().Select(item => item, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("Collection_Value")]
        //[Benchmark]
        //public int StructLinq_Collection_Value()
        //{
        //    var sum = 0;
        //    foreach (var item in collectionValue.ToStructEnumerable().Select(item => item, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("List_Value")]
        //[Benchmark]
        //public int StructLinq_List_Value()
        //{
        //    var sum = 0;
        //    foreach (var item in listValue.ToStructEnumerable().Select(item => item, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("Enumerable_Reference")]
        //[Benchmark]
        //public int StructLinq_Enumerable_Reference()
        //{
        //    var sum = 0;
        //    foreach (var item in enumerableReference.ToStructEnumerable().Select(item => item, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("Collection_Reference")]
        //[Benchmark]
        //public int StructLinq_Collection_Reference()
        //{
        //    var sum = 0;
        //    foreach (var item in collectionReference.ToStructEnumerable().Select(item => item, x => x))
        //        sum += item;
        //    return sum;
        //}

        //[BenchmarkCategory("List_Reference")]
        //[Benchmark]
        //public int StructLinq_List_Reference()
        //{
        //    var sum = 0;
        //    foreach (var item in listReference.ToStructEnumerable().Select(item => item, x => x))
        //        sum += item;
        //    return sum;
        //}

        // -------------------


//        [BenchmarkCategory("Array")]
//        [Benchmark]
//        public int Hyperlinq_Array_For()
//        {
//            var source = array.AsValueEnumerable().Select(item => item);
//            var sum = 0;
//            for (var index = 0; index < source.Count; index++)
//                sum += source[index];
//            return sum;
//        }

//#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
//        [BenchmarkCategory("Array")]
//        [Benchmark]
//        public int Hyperlinq_Array_Foreach()
//        {
//            var sum = 0;
//            foreach (var item in array.AsValueEnumerable().Select(item => item))
//                sum += item;
//            return sum;
//        }
//#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span_For()
        {
            var source = array.AsSpan().Select(item => item);
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Span_Foreach()
        {
            var sum = 0;
            foreach (var item in array.AsSpan().Select(item => item))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory_For()
        {
            var source = memory.AsValueEnumerable().Select(item => item);
            var sum = 0;
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
            return sum;
        }

#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        [BenchmarkCategory("Array")]
        [Benchmark]
        public int Hyperlinq_Memory_Foreach()
        {
            var sum = 0;
            foreach (var item in memory.AsValueEnumerable().Select(item => item))
                sum += item;
            return sum;
        }
#pragma warning restore HLQ010 // Consider using a 'for' loop instead.

        //        [BenchmarkCategory("Enumerable_Value")]
        //        [Benchmark]
        //        public int Hyperlinq_Enumerable_Value()
        //        {
        //            var sum = 0;
        //            foreach (var item in EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
        //                .Select(item => item))
        //                sum += item;
        //            return sum;
        //        }

        //        [BenchmarkCategory("Collection_Value")]
        //        [Benchmark]
        //        public int Hyperlinq_Collection_Value()
        //        {
        //            var sum = 0;
        //            foreach (var item in ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
        //                .Select(item => item))
        //                sum += item;
        //            return sum;
        //        }

        //        [BenchmarkCategory("List_Value")]
        //        [Benchmark]
        //        public int Hyperlinq_List_Value_For()
        //        {
        //            var source = listValue.AsValueEnumerable().Select(item => item);
        //            var sum = 0;
        //            for (var index = 0; index < source.Count; index++)
        //            {
        //                var item = source[index];
        //                sum += item;
        //            }
        //            return sum;
        //        }

        //        [BenchmarkCategory("List_Value")]
        //        [Benchmark]
        //        public int Hyperlinq_List_Value_Foreach()
        //        {
        //            var sum = 0;
        //            foreach (var item in listValue.AsValueEnumerable().Select(item => item))
        //                sum += item;
        //            return sum;
        //        }

        //        [BenchmarkCategory("Enumerable_Reference")]
        //        [Benchmark]
        //        public int Hyperlinq_Enumerable_Reference()
        //        {
        //            var sum = 0;
        //            foreach (var item in enumerableReference.AsValueEnumerable().Select(item => item))
        //                sum += item;
        //            return sum;
        //        }

        //        [BenchmarkCategory("Collection_Reference")]
        //        [Benchmark]
        //        public int Hyperlinq_Collection_Reference()
        //        {
        //            var sum = 0;
        //            foreach (var item in collectionReference.AsValueEnumerable().Select(item => item))
        //                sum += item;
        //            return sum;
        //        }

        //        [BenchmarkCategory("List_Reference")]
        //        [Benchmark]
        //        public int Hyperlinq_List_Reference_For()
        //        {
        //            var source = listReference.AsValueEnumerable().Select(item => item);
        //            var sum = 0;
        //            for (var index = 0; index < source.Count; index++)
        //                sum += source[index];
        //            return sum;
        //        }

        //#pragma warning disable HLQ010 // Consider using a 'for' loop instead.
        //        [BenchmarkCategory("List_Reference")]
        //        [Benchmark]
        //        public int Hyperlinq_List_Reference_Foreach()
        //        {
        //            var sum = 0;
        //            foreach (var item in listReference.AsValueEnumerable().Select(item => item))
        //                sum += item;
        //            return sum;
        //        }
        //#pragma warning restore HLQ010 // Consider using a 'for' loop instead.
    }
}
