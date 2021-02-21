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
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentValueEnumerableRef<TSource> AsValueEnumerableRef<TSource>(this ArraySegment<TSource> source)
            => new(source);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentValueEnumerableRef<TSource>
            : IValueReadOnlyList<TSource, ArraySegmentValueEnumerableRef<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly ArraySegment<TSource> source;

            internal ArraySegmentValueEnumerableRef(ArraySegment<TSource> source)
                => this.source = source;

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public readonly ref TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if ((uint)index >= (uint)source.Count) Throw.IndexOutOfRangeException();

                    return ref source.Array![source.Offset + index];
                }
            }
            TSource IReadOnlyList<TSource>.this[int index]
                => this[index];
            TSource IList<TSource>.this[int index]
            {
                get => this[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SpanEnumeratorRef<TSource> GetEnumerator()
                => new(source);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator()
                => new(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(source);


            bool ICollection<TSource>.IsReadOnly
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(Span<TSource> span)
                => source.AsSpan().CopyTo(span);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => Copy(source, array.AsSpan().Slice(arrayIndex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => ((ICollection<TSource>)source).Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(TSource item)
                => ArrayExtensions.IndexOf(source.AsSpan(), item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item)
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear()
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly ArraySegment<TSource> source;
                int index;

                internal DisposableEnumerator(ArraySegment<TSource> source)
                {
                    this.source = source;
                    index = -1;
                }

                public readonly ref TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get
                    {
                        if ((uint)index >= (uint)source.Count) Throw.IndexOutOfRangeException();

                        return ref source.Array![source.Offset + index];
                    }
                }
                readonly TSource IEnumerator<TSource>.Current
                    => this.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => this.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index < source.Count;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                [ExcludeFromCodeCoverage]
                public void Reset()
                    => index = -1;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Dispose() { }
            }

            #region Aggregation

            #endregion

            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerableRef<TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerableRef<TSource> AsValueEnumerable()
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
                => source.AsSpan().ToDictionaryRef(keySelector, comparer);

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

            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentWhereEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where(FunctionIn<TSource, bool> predicate)
            //     => source.WhereRef(predicate);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
            //     where TPredicate : struct, IFunctionIn<TSource, bool>
            //     => source.WhereRef(predicate);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentWhereAtEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where(FunctionIn<TSource, int, bool> predicate)
            //     => source.WhereRef(predicate);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
            //     where TPredicate : struct, IFunctionIn<TSource, int, bool>
            //     => source.WhereAtRef(predicate);

            #endregion

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerableRef<TSource> Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(source.Count, count);
                return new ArraySegmentValueEnumerableRef<TSource>(new ArraySegment<TSource>(source.Array!, source.Offset + skipCount, takeCount));
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerableRef<TSource> Take(int count)
                => new(new ArraySegment<TSource>(source.Array!, source.Offset, Utils.Take(source.Count, count)));

            #endregion

            #region Projection

            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentSelectEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TResult>(FunctionIn<TSource, TResult> selector)
            //     => source.SelectRef(selector);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentSelectEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
            //     where TSelector : struct, IFunctionIn<TSource, TResult>
            //     => source.SelectRef<TSource, TResult, TSelector>(selector);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentSelectAtEnumerable<TSource, TResult, FunctionInWrapper<TSource, int, TResult>> Select<TResult>(FunctionIn<TSource, int, TResult> selector)
            //     => source.SelectRef(selector);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
            //     where TSelector : struct, IFunctionIn<TSource, int, TResult>
            //     => source.SelectAtRef<TSource, TResult, TSelector>(selector);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionInWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(FunctionIn<TSource, TSubEnumerable> selector)
            //     where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //     where TSubEnumerator : struct, IEnumerator<TResult>
            //     => source.SelectManyRef<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);
            //
            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // public ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
            //     where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //     where TSubEnumerator : struct, IEnumerator<TResult>
            //     where TSelector : struct, IFunctionIn<TSource, TSubEnumerable>
            //     => source.SelectManyRef<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, bool> predicate)
                => All(new FunctionInWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => source.AsSpan().AllRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, int, bool> predicate)
                => AllAt(new FunctionInWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, int, bool>
                => source.AsSpan().AllAtRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AsSpan().Any();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, bool> predicate)
                => Any(new FunctionInWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => source.AsSpan().AnyRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, int, bool> predicate)
                => AnyAt(new FunctionInWrapper<TSource, int, bool>(predicate));

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
            public ArraySegmentDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => source.Distinct(comparer);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ArraySegmentValueEnumerableRef<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentValueEnumerableRef<int> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentValueEnumerableRef<int?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentValueEnumerableRef<long> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentValueEnumerableRef<long?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentValueEnumerableRef<float> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentValueEnumerableRef<float?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentValueEnumerableRef<double> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentValueEnumerableRef<double?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentValueEnumerableRef<decimal> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentValueEnumerableRef<decimal?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this ArraySegmentValueEnumerableRef<TSource> source, TSource value)
            where TSource : struct
            => source.source.AsSpan().ContainsVector(value);

        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static ArraySegmentSelectVectorEnumerable<TSource, TResult, FunctionInWrapper<Vector<TSource>, Vector<TResult>>, FunctionInWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ArraySegmentValueEnumerableRef<TSource> source, FunctionIn<Vector<TSource>, Vector<TResult>> vectorSelector, FunctionIn<TSource, TResult> selector)
        //     where TSource : struct
        //     where TResult : struct
        //     => source.source.SelectVector(vectorSelector, selector);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static ArraySegmentSelectVectorEnumerable<TSource, TResult, TSelector, TSelector> SelectVector<TSource, TResult, TSelector>(this ArraySegmentValueEnumerableRef<TSource> source, TSelector selector = default)
        //     where TSelector : struct, IFunctionIn<Vector<TSource>, Vector<TResult>>, IFunctionIn<TSource, TResult>
        //     where TSource : struct
        //     where TResult : struct
        //     => source.source.SelectVector<TSource, TResult, TSelector, TSelector>(selector, selector);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static ArraySegmentSelectVectorEnumerable<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ArraySegmentValueEnumerableRef<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
        //     where TVectorSelector : struct, IFunctionIn<Vector<TSource>, Vector<TResult>>
        //     where TSelector : struct, IFunctionIn<TSource, TResult>
        //     where TSource : struct
        //     where TResult : struct
        //     => source.source.SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);
    }
}