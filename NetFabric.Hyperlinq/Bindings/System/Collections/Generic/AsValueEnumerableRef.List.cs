using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ListValueEnumerableRef<TSource> AsValueEnumerableRef<TSource>(this List<TSource> source)
            => new(source);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ListValueEnumerableRef<TSource>
            : IValueReadOnlyList<TSource, List<TSource>.Enumerator>
            , IList<TSource>
        {
            internal readonly List<TSource> source;

            public ListValueEnumerableRef(List<TSource> source)
                => this.source = source;

            public readonly int Count
                => source.Count;

            public readonly TSource this[int index]
                => source[index];
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource>.Enumerator GetEnumerator()
                => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly
                => true;


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(Span<TSource> span)
                => source.AsSpan().CopyTo(span);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => source.CopyTo(array, arrayIndex);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => source.AsSpan().Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear()
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item)
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();


            #region Aggregation

            #endregion

            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ListValueEnumerableRef<TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ListValueEnumerableRef<TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.AsSpan().ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => source.AsSpan().ToArray(memoryPool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.AsSpan().ToList();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(FunctionIn<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.AsSpan().ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunctionIn<TSource, TKey>
                => source.AsSpan().ToDictionaryRef<TSource, TKey, TKeySelector>(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(FunctionIn<TSource, TKey> keySelector, FunctionIn<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.AsSpan().ToDictionary(keySelector, elementSelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunctionIn<TSource, TKey>
                where TElementSelector : struct, IFunctionIn<TSource, TElement>
                => source.AsSpan().ToDictionaryRef<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);

            #endregion

            #region Element

            public Option<TSource> ElementAt(int index)
                => source.AsSpan().ElementAt(index);

            public Option<TSource> First()
                => source.AsSpan().First();

            public Option<TSource> Single()
                => source.AsSpan().Single();

            #endregion

            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereRefEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where(FunctionIn<TSource, bool> predicate)
                => source.AsArraySegment().Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereRefEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => source.AsArraySegment().WhereRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where(FunctionIn<TSource, int, bool> predicate)
                => source.AsArraySegment().Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereAtRefEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunctionIn<TSource, int, bool>
                => source.AsArraySegment().WhereAtRef(predicate);

            #endregion

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegment<TSource> Skip(int count)
                => source.AsArraySegment().Skip(count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegment<TSource> Take(int count)
                => source.AsArraySegment().Take(count);

            #endregion

            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TResult>(FunctionIn<TSource, TResult> selector)
                => source.AsArraySegment().Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunctionIn<TSource, TResult>
                => source.AsArraySegment().SelectRef<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectAtRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, int, TResult>> Select<TResult>(FunctionIn<TSource, int, TResult> selector)
                => source.AsArraySegment().Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunctionIn<TSource, int, TResult>
                => source.AsArraySegment().SelectAtRef<TSource, TResult, TSelector>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.ArraySegmentSelectManyRefEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionInWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(FunctionIn<TSource, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult>
            //    => source.AsArraySegment().SelectMany<TSubEnumerable, TSubEnumerator, TResult>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.ArraySegmentSelectManyRefEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
            //    where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult>
            //    where TSelector : struct, IFunctionIn<TSource, TSubEnumerable>
            //    => source.AsArraySegment().SelectManyRef<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, bool> predicate)
                => source.AsSpan().All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => source.AsSpan().AllRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, int, bool> predicate)
                => source.AsSpan().All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, int, bool>
                => source.AsSpan().AllAtRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AsSpan().Any();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, bool> predicate)
                => source.AsSpan().Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => source.AsSpan().AnyRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, int, bool> predicate)
                => source.AsSpan().Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, int, bool>
                => source.AsSpan().AnyAtRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => source.AsSpan().Contains(value, comparer);

            #endregion

            #region Set

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => source.AsArraySegment().Distinct(comparer);

            #endregion

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ListValueEnumerableRef<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ListValueEnumerableRef<int> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ListValueEnumerableRef<int?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ListValueEnumerableRef<long> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ListValueEnumerableRef<long?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ListValueEnumerableRef<float> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ListValueEnumerableRef<float?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ListValueEnumerableRef<double> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ListValueEnumerableRef<double?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ListValueEnumerableRef<decimal> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ListValueEnumerableRef<decimal?> source)
            => source.source.AsSpan().Sum();
    }
}