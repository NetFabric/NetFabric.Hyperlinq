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

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentValueEnumerable<TSource> AsValueEnumerable<TSource>(this ArraySegment<TSource> source)
            => new(source);

        [GeneratorBindings(source: "((ReadOnlySpan<TSource>)source.AsSpan())", sourceImplements: "ReadOnlySpan`1")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentValueEnumerable<TSource>
            : IValueReadOnlyList<TSource, ArraySegmentValueEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly ArraySegment<TSource> source;

            internal ArraySegmentValueEnumerable(ArraySegment<TSource> source)
                => this.source = source;

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    ThrowIfArgument.OutOfRange(index, Count, nameof(index));
                    return source.Array![source.Offset + index];
                }
            }

            TSource IList<TSource>.this[int index]
            {
                get => this[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanEnumerator<TSource> GetEnumerator()
                => new(source);

            DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator()
                => new(source);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(source);

            IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(source);


            bool ICollection<TSource>.IsReadOnly
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => source.AsSpan().CopyTo(array.AsSpan(arrayIndex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => source.Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(TSource item)
            {
                var index = Array.IndexOf(source.Array!, item, source.Offset, source.Count);
                return index < 0 
                    ? -1
                    : index - source.Offset;
            }
            
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

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source.Array![source.Offset + index];
                }
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => Current;

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
            public ArraySegmentValueEnumerable<TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegment<TSource> AsEnumerable()
                => source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.AsSpan().ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => source.AsSpan().ToArray(pool, clearOnDispose);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToList();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToDictionary(keySelector, elementSelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);

            #endregion

            #region Element

            public Option<TSource> ElementAt(int index)
                => index < 0 || index >= source.Count 
                    ? Option.None 
                    : Option.Some(source.Array![source.Offset + index]);

            public Option<TSource> First()
                => source switch
                {
                    { Count: 0 } => Option.None,
                    _ => Option.Some(source.Array![source.Offset])
                };
            
            public Option<TSource> Single()
                => source switch
                {
                    { Count: 1 } => Option.Some(source.Array![source.Offset]),
                    _ => Option.None,
                };
            
            #endregion

            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where(Func<TSource, bool> predicate)
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where(Func<TSource, int, bool> predicate)
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.WhereAt(predicate);

            #endregion

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerable<TSource> Skip(int count)
            {
                var (newOffset, newCount) = Utils.Skip(source.Count, count);
                return new ArraySegmentValueEnumerable<TSource>(new ArraySegment<TSource>(source.Array!, source.Offset + newOffset, newCount));
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentValueEnumerable<TSource> Take(int count)
                => new(new ArraySegment<TSource>(source.Array!, source.Offset, Utils.Take(source.Count, count)));

            #endregion

            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => source.Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.Select<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
                => source.Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, int, TResult>
                => source.SelectAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                where TSelector : struct, IFunction<TSource, TSubEnumerable>
                => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AllAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Any();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AnyAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).Contains(value, comparer);

            #endregion

            #region Set

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => source.Distinct(comparer);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ArraySegmentValueEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ArraySegmentValueEnumerable<TSource> source, Func<TSource, bool> predicate)
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TPredicate>(this ArraySegmentValueEnumerable<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ArraySegmentValueEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            => source.Count(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TSource, TPredicate>(this ArraySegmentValueEnumerable<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.CountAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentValueEnumerable<int> source)
            => ((ReadOnlySpan<int>)source.source.AsSpan()).SumVector<int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ArraySegmentValueEnumerable<int?> source)
            => ((ReadOnlySpan<int?>)source.source.AsSpan()).Sum<int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ArraySegmentValueEnumerable<nint> source)
            => ((ReadOnlySpan<nint>)source.source.AsSpan()).SumVector<nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum(this ArraySegmentValueEnumerable<nint?> source)
            => ((ReadOnlySpan<nint?>)source.source.AsSpan()).Sum<nint?, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ArraySegmentValueEnumerable<nuint> source)
            => ((ReadOnlySpan<nuint>)source.source.AsSpan()).SumVector<nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum(this ArraySegmentValueEnumerable<nuint?> source)
            => ((ReadOnlySpan<nuint?>)source.source.AsSpan()).Sum<nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentValueEnumerable<long> source)
            => ((ReadOnlySpan<long>)source.source.AsSpan()).SumVector<long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ArraySegmentValueEnumerable<long?> source)
            => ((ReadOnlySpan<long?>)source.source.AsSpan()).Sum<long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentValueEnumerable<float> source)
            => ((ReadOnlySpan<float>)source.source.AsSpan()).SumVector<float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ArraySegmentValueEnumerable<float?> source)
            => ((ReadOnlySpan<float?>)source.source.AsSpan()).Sum<float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentValueEnumerable<double> source)
            => ((ReadOnlySpan<double>)source.source.AsSpan()).SumVector<double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ArraySegmentValueEnumerable<double?> source)
            => ((ReadOnlySpan<double?>)source.source.AsSpan()).Sum<double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentValueEnumerable<decimal> source)
            => ((ReadOnlySpan<decimal>)source.source.AsSpan()).Sum<decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ArraySegmentValueEnumerable<decimal?> source)
            => ((ReadOnlySpan<decimal?>)source.source.AsSpan()).Sum<decimal?, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this ArraySegmentValueEnumerable<TSource> source, TSource value)
            where TSource : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).ContainsVector(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ArraySegmentValueEnumerable<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SelectVector(vectorSelector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, TSelector, TSelector> SelectVector<TSource, TResult, TSelector>(this ArraySegmentValueEnumerable<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SelectVector<TSource, TResult, TSelector, TSelector>(selector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ArraySegmentValueEnumerable<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);
    }
}