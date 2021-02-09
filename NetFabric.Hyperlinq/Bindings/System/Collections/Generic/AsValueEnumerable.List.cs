using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ListValueEnumerable<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => new(source);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ListValueEnumerable<TSource>
            : IValueReadOnlyList<TSource, List<TSource>.Enumerator>
            , IList<TSource>
        {
            internal readonly List<TSource> source;

            public ListValueEnumerable(List<TSource> source)
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
            public bool Contains(TSource item)
                => source.Contains(item);

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
            public ListValueEnumerable<TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ListValueEnumerable<TSource> AsValueEnumerable()
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
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.AsSpan().ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.AsSpan().ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.AsSpan().ToDictionary<TSource, TKey, TElement>(keySelector, elementSelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.AsSpan().ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);

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
            public ArrayExtensions.ArraySegmentWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where(Func<TSource, bool> predicate)
                => source.AsArraySegment().Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.AsArraySegment().Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where(Func<TSource, int, bool> predicate)
                => source.AsArraySegment().Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.AsArraySegment().WhereAt(predicate);

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
            public ArrayExtensions.ArraySegmentSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => source.AsArraySegment().Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.AsArraySegment().Select<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
                => source.AsArraySegment().Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, int, TResult>
                => source.AsArraySegment().SelectAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                => source.AsArraySegment().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                where TSelector : struct, IFunction<TSource, TSubEnumerable>
                => source.AsArraySegment().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => source.AsSpan().All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.AsSpan().All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => source.AsSpan().All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.AsSpan().AllAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AsSpan().Any();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => source.AsSpan().Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.AsSpan().Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => source.AsSpan().Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.AsSpan().AnyAt(predicate);

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
        public static int Count<TSource>(this ListValueEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ListValueEnumerable<int> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ListValueEnumerable<int?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ListValueEnumerable<long> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ListValueEnumerable<long?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ListValueEnumerable<float> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ListValueEnumerable<float?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ListValueEnumerable<double> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ListValueEnumerable<double?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ListValueEnumerable<decimal> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ListValueEnumerable<decimal?> source)
            => source.source.AsSpan().Sum();

#if NET5_0

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this ListValueEnumerable<TSource> source, TSource value)
            where TSource : struct
            => source.source.AsSpan().ContainsVector(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectVectorEnumerable<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ListValueEnumerable<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.source.AsMemory().SelectVector(vectorSelector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ListValueEnumerable<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.source.AsMemory().SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);

#endif    
    }
}