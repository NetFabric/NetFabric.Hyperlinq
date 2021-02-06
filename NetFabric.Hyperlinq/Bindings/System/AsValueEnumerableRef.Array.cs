using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayBindings
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableRef<TSource> AsValueEnumerableRef<TSource>(this TSource[] source)
            => new(source);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerableRef<TSource>
            : IValueReadOnlyList<TSource, ValueEnumerableRef<TSource>.Enumerator>
            , IList<TSource>
        {
            internal readonly TSource[] source;

            internal ValueEnumerableRef(TSource[] source)
                => this.source = source;

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Length;
            }

            public readonly ref TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => ref source[index];
            }
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
            public readonly ForeachEnumerator GetEnumerator()
                => new(source);
            readonly Enumerator IValueEnumerable<TSource, Enumerator>.GetEnumerator()
                => new(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(source);


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
            public int IndexOf(TSource item)
                => Array.IndexOf(source, item);

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

            [StructLayout(LayoutKind.Sequential)]
            public struct ForeachEnumerator
            {
                int index;
                readonly int end;
                readonly TSource[] source;

                internal ForeachEnumerator(TSource[] source)
                {
                    this.source = source;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly ref TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly TSource[] source;

                internal Enumerator(TSource[] source)
                {
                    this.source = source;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly ref TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source[index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;

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
            public ValueEnumerableRef<TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableRef<TSource> AsValueEnumerable()
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
                => new ArraySegment<TSource>(source).Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereRefEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => new ArraySegment<TSource>(source).WhereRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where(FunctionIn<TSource, int, bool> predicate)
                => new ArraySegment<TSource>(source).Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentWhereAtRefEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunctionIn<TSource, int, bool>
                => new ArraySegment<TSource>(source).WhereAtRef(predicate);

            #endregion

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegment<TSource> Skip(int count)
                => new ArraySegment<TSource>(source).Skip(count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegment<TSource> Take(int count)
                => new ArraySegment<TSource>(source).Take(count);

            #endregion

            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TResult>(FunctionIn<TSource, TResult> selector)
                => new ArraySegment<TSource>(source).Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunctionIn<TSource, TResult>
                => new ArraySegment<TSource>(source).SelectRef<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectAtRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, int, TResult>> Select<TResult>(FunctionIn<TSource, int, TResult> selector)
                => new ArraySegment<TSource>(source).Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunctionIn<TSource, int, TResult>
                => new ArraySegment<TSource>(source).SelectAtRef<TSource, TResult, TSelector>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.ArraySegmentSelectManyRefEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionInWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(FunctionIn<TSource, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult>
            //    => new ArraySegment<TSource>(source).SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionInWrapper<TSource, TSubEnumerable>>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.ArraySegmentSelectManyRefEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
            //    where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult>
            //    where TSelector : struct, IFunctionIn<TSource, TSubEnumerable>
            //    => new ArraySegment<TSource>(source).SelectManyRef<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

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
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunctionIn<TSource, int, bool>
                => source.AsSpan().AnyAtRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => source.AsSpan().Contains(value, comparer);

            #endregion

            #region Set

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.ArraySegmentDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => new ArraySegment<TSource>(source).Distinct(comparer);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this in ValueEnumerableRef<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerableRef<int> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerableRef<int?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerableRef<long> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerableRef<long?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerableRef<float> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerableRef<float?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerableRef<double> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerableRef<double?> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerableRef<decimal> source)
            => source.source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerableRef<decimal?> source)
            => source.source.AsSpan().Sum();
    }
}