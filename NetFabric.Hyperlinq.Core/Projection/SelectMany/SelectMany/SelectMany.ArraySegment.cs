using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(this in ArraySegment<TSource> source, Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>>(new FunctionWrapper<TSource, TSubEnumerable>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => new(source, selector);


        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>
            : IValueEnumerable<TResult, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
        {
            readonly ArraySegment<TSource> source;
            readonly TSelector selector;

            internal ArraySegmentSelectManyEnumerable(in ArraySegment<TSource> source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator()
                => new(in this);

            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TSource[]? source;
#pragma warning disable IDE0044 // Add readonly modifier
                TSelector selector;
                TSubEnumerator subEnumerator;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly int end;
                EnumeratorState state;
                int sourceIndex;

                internal Enumerator(in ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    selector = enumerable.selector;
                    state = enumerable.source.Count is 0
                        ? EnumeratorState.Complete
                        : EnumeratorState.Enumerating;
                    sourceIndex = enumerable.source.Offset - 1;
                    end = sourceIndex + enumerable.source.Count;
                    subEnumerator = default;
                }

                public readonly TResult Current
                    => subEnumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => subEnumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case EnumeratorState.Enumerating:
                            if (++sourceIndex >= end)
                            {
                                state = EnumeratorState.Complete;
                                return false;
                            }

                            var enumerable = selector.Invoke(source![sourceIndex]);
                            subEnumerator = enumerable.GetEnumerator();

                            state = EnumeratorState.EnumeratingSub;
                            goto case EnumeratorState.EnumeratingSub;

                        case EnumeratorState.EnumeratingSub:
                            if (!subEnumerator.MoveNext())
                            {
                                state = EnumeratorState.Enumerating;
                                goto case EnumeratorState.Enumerating;
                            }
                            return true;

                        default:
                            return false;
                    }
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() 
                    => subEnumerator.Dispose();
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => this.Count<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => this.Any<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TResult, bool>
                => this.Any<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TResult, int, bool>
                => this.AnyAt<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.WhereAtEnumerable<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, IFunction<TResult, int, bool>
                => ValueEnumerableExtensions.WhereAt<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.WhereEnumerable<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate> Where<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, IFunction<TResult, bool>
                => ValueEnumerableExtensions.Where<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(this, predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.SelectEnumerable<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
            => ValueEnumerableExtensions.Select<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.SelectAtEnumerable<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
            => ValueEnumerableExtensions.SelectAt<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2>(this, selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => this.ElementAt<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(index);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => this.First<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => this.Single<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> AsValueEnumerable()
                => this;

            public ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> AsEnumerable()
                => this;

            #endregion
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.SkipEnumerable<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> Skip(int count)
                => ValueEnumerableExtensions.Skip<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.TakeEnumerable<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> Take(int count)
                => ValueEnumerableExtensions.Take<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, count);

            #endregion
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int, TSelector> source)
            where TSubEnumerable : IValueEnumerable<int, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<int>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int, TSelector>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<int?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<int?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int?, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int?, TSelector>.Enumerator, int?, int>();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nint, TSelector> source)
            where TSubEnumerable : IValueEnumerable<nint, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<nint>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nint, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nint, TSelector>.Enumerator, nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nint?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<nint?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<nint?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nint?, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nint?, TSelector>.Enumerator, nint?, nint>();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nuint, TSelector> source)
            where TSubEnumerable : IValueEnumerable<nuint, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<nuint>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nuint, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nuint, TSelector>.Enumerator, nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nuint?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<nuint?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<nuint?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nuint?, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, nuint?, TSelector>.Enumerator, nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long, TSelector> source)
            where TSubEnumerable : IValueEnumerable<long, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<long>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long, TSelector>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<long?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<long?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long?, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long?, TSelector>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float, TSelector> source)
            where TSubEnumerable : IValueEnumerable<float, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<float>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float, TSelector>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<float?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<float?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float?, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float?, TSelector>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double, TSelector> source)
            where TSubEnumerable : IValueEnumerable<double, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<double>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double, TSelector>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<double?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<double?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double?, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double?, TSelector>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal, TSelector> source)
            where TSubEnumerable : IValueEnumerable<decimal, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<decimal>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal, TSelector>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<decimal?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<decimal?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal?, TSelector>, ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal?, TSelector>.Enumerator, decimal?, decimal>();

    }
}

