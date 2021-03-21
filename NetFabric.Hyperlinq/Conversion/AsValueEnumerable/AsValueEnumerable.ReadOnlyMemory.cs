using System;
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
        public static MemoryValueEnumerable<TSource> AsValueEnumerable<TSource>(this ReadOnlyMemory<TSource> source)
            => new(source);

        [GeneratorBindings(source: "source.Span", sourceImplements: "ReadOnlySpan`1")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryValueEnumerable<TSource>
            : IValueReadOnlyList<TSource, MemoryValueEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly ReadOnlyMemory<TSource> source;

            internal MemoryValueEnumerable(ReadOnlyMemory<TSource> source)
                => this.source = source;

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Length;
            }

            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Span[index];
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
            public readonly SpanEnumerator<TSource> GetEnumerator()
                => new(source.Span);
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
                => ArrayExtensions.IndexOf(source.Span, item);

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
                readonly ReadOnlyMemory<TSource> source;
                int index;

                internal DisposableEnumerator(ReadOnlyMemory<TSource> source)
                {
                    this.source = source;
                    index = -1;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source.Span[index];
                }
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
            public MemoryValueEnumerable<TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryValueEnumerable<TSource> AsValueEnumerable()
                => this;

            #endregion

            #region Element

            #endregion
            
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where(Func<TSource, bool> predicate)
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereEnumerable<TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, bool>
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where(Func<TSource, int, bool> predicate)
                => source.Where(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TSource, int, bool>
                => source.WhereAt(predicate);

            #endregion
             
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryValueEnumerable<TSource> Skip(int count)
            {
                var (skipCount, takeCount) = Partition.Skip(source.Length, count);
                return new MemoryValueEnumerable<TSource>(source.Slice(skipCount, takeCount));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryValueEnumerable<TSource> Take(int count)
                => new(source.Slice(0, Partition.Take(source.Length, count)));

            #endregion

            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => source.Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectEnumerable<TSource, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.Select<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TResult>(Func<TSource, int, TResult> selector)
                => source.Select(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, int, TResult>
                => source.SelectAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector = default)
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult>
                where TSelector : struct, IFunction<TSource, TSubEnumerable>
                => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);

            #endregion

            #region Quantifier

            #endregion

            #region Set

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryDistinctEnumerable<TSource> Distinct(IEqualityComparer<TSource>? comparer = default)
                => source.Distinct(comparer);

            #endregion

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
            {
                comparer ??= EqualityComparer<TSource>.Default;

                var enumerator = GetEnumerator();
                using var otherEnumerator = other.GetEnumerator();
                while (true)
                {
                    var thisEnded = !enumerator.MoveNext();
                    var otherEnded = !otherEnumerator.MoveNext();

                    if (thisEnded != otherEnded)
                        return false;

                    if (thisEnded)
                        return true;

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this MemoryValueEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this MemoryValueEnumerable<int> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this MemoryValueEnumerable<int?> source)
            => source.source.Span.Sum<int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this MemoryValueEnumerable<long> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this MemoryValueEnumerable<long?> source)
            => source.source.Span.Sum<long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this MemoryValueEnumerable<float> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum(this MemoryValueEnumerable<float?> source)
            => source.source.Span.Sum<float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this MemoryValueEnumerable<double> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(this MemoryValueEnumerable<double?> source)
            => source.source.Span.Sum<double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this MemoryValueEnumerable<decimal> source)
            => source.source.Span.Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this MemoryValueEnumerable<decimal?> source)
            => source.source.Span.Sum<decimal?, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsVector<TSource>(this MemoryValueEnumerable<TSource> source, TSource value)
            where TSource : struct
            => source.source.Span.ContainsVector(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this MemoryValueEnumerable<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.source.Span.SelectVector(vectorSelector, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectVectorContext<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this MemoryValueEnumerable<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.source.Span.SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);
    }
}