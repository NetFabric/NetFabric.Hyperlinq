using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyMemoryBindings
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableRef<TSource> AsValueEnumerableRef<TSource>(this ReadOnlyMemory<TSource> source)
            => new(source);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ValueEnumerableRef<TSource>
            : IValueReadOnlyList<TSource, ValueEnumerableRef<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly ReadOnlyMemory<TSource> source;

            internal ValueEnumerableRef(ReadOnlyMemory<TSource> source)
                => this.source = source;

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Length;
            }

            public readonly ref readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => ref source.Span[index];
            }
            TSource IReadOnlyList<TSource>.this[int index]
                => source.Span[index];
            TSource IList<TSource>.this[int index]
            {
                get => source.Span[index];

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
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
                => source.Span.CopyTo(span);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex)
                => CopyTo(array.AsSpan(arrayIndex));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => source.Span.Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(TSource item)
            {
                if (source.Length is 0)
                    return -1;

                var span = source.Span;
                if (Utils.IsValueType<TSource>())
                {
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(span[index], item))
                            return index;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (defaultComparer.Equals(span[index], item))
                            return index;
                    }
                }
                return -1;
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
            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                int index;

                internal Enumerator(ReadOnlyMemory<TSource> source)
                {
                    this.source = source.Span;
                    index = -1;
                }

                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index < source.Length;
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                int index;

                internal DisposableEnumerator(ReadOnlyMemory<TSource> source)
                {
                    this.source = source;
                    index = -1;
                }

                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source.Span[index];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source.Span[index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source.Span[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index < source.Length;

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
            public ValueEnumerableRef<TSource> AsValueEnumerableRef()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyMemory<TSource> ToArray()
                => source.Span.ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => source.Span.ToArray(memoryPool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.Span.ToList();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(FunctionIn<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.Span.ToDictionary(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunctionIn<TSource, TKey>
                => source.Span.ToDictionaryRef(keySelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(FunctionIn<TSource, TKey> keySelector, FunctionIn<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => source.Span.ToDictionary<TSource, TKey, TElement>(keySelector, elementSelector, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunctionIn<TSource, TKey>
                where TElementSelector : struct, IFunctionIn<TSource, TElement>
                => source.Span.ToDictionaryRef<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);

            #endregion

            #region Element

            public Option<TSource> ElementAt(int index)
                => source.Span.ElementAt(index);

            public Option<TSource> First()
                => source.Span.First();

            public Option<TSource> Single()
                => source.Span.Single();

            #endregion

            #region Filtering

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemoryWhereRefEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where(FunctionIn<TSource, bool> predicate)
            //    => source.Where(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemoryWhereRefEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
            //    where TPredicate : struct, IFunctionIn<TSource, bool>
            //    => source.WhereRef(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemoryWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where(FunctionIn<TSource, int, bool> predicate)
            //    => source.Where(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemoryWhereAtRefEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
            //    where TPredicate : struct, IFunctionIn<TSource, int, bool>
            //    => source.WhereAtRef(predicate);

            #endregion

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyMemory<TSource> Skip(int count)
                => source.Skip(count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyMemory<TSource> Take(int count)
                => source.Take(count);

            #endregion

            #region Projection

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemorySelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TResult>(FunctionIn<TSource, TResult> selector)
            //    => source.Select(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemorySelectRefEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
            //    where TSelector : struct, IFunctionIn<TSource, TResult>
            //    => source.SelectRef<TSource, TResult, TSelector>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemorySelectAtRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, int, TResult>> Select<TResult>(FunctionIn<TSource, int, TResult> selector)
            //    => source.Select(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemorySelectAtRefEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
            //    where TSelector : struct, IFunctionIn<TSource, int, TResult>
            //    => source.SelectAtRef<TSource, TResult, TSelector>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemorySelectManyRefEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionInWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(FunctionIn<TSource, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerableRef<TResult, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult>
            //    => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArrayExtensions.MemorySelectManyRefEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
            //    where TSubEnumerable : IValueEnumerableRef<TResult, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult>
            //    where TSelector : struct, IFunctionIn<TSource, TSubEnumerable>
            //    => source.SelectManyRef<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

            #endregion

            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, bool> predicate)
                => source.Span.All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => source.Span.AllRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(FunctionIn<TSource, int, bool> predicate)
                => source.Span.All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, int, bool>
                => source.Span.AllAtRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Span.Any();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, bool> predicate)
                => source.Span.Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, bool>
                => source.Span.AnyRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(FunctionIn<TSource, int, bool> predicate)
                => source.Span.Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunctionIn<TSource, int, bool>
                => source.Span.AnyAtRef(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => source.Span.Contains(value, comparer);

            #endregion

            #region Set

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArrayExtensions.MemoryDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => source.Distinct(comparer);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerableRef<int> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this ValueEnumerableRef<int?> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerableRef<long> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this ValueEnumerableRef<long?> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerableRef<float> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this ValueEnumerableRef<float?> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerableRef<double> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this ValueEnumerableRef<double?> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerableRef<decimal> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this ValueEnumerableRef<decimal?> source)
            => source.source.Span.Sum();
    }
}