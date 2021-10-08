using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>>(new FunctionWrapper<TSource, TSubEnumerable>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => new(source, selector);


        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
        {
            readonly ReadOnlySpan<TSource> source;
            readonly TSelector selector;

            internal SpanSelectManyEnumerable(ReadOnlySpan<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new(this);

            [StructLayout(LayoutKind.Auto)]
            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
#pragma warning disable IDE0044 // Add readonly modifier
                TSelector selector;
                TSubEnumerator subEnumerator;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly int end;
                EnumeratorState state;
                int sourceIndex;

                internal Enumerator(SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    state = EnumeratorState.Enumerating;
                    sourceIndex = -1;
                    end = sourceIndex + enumerable.source.Length;
                    subEnumerator = default;
                }

                public readonly TResult Current
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

                            var enumerable = selector.Invoke(source[sourceIndex]);
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
/*
            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => this.Count<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => this.Any<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(Func<TResult, bool> predicate)
                => this.Any<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TResult, bool>
                => this.Any<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(Func<TResult, int, bool> predicate)
                => this.Any<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TResult, int, bool>
                => this.AnyAt<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, FunctionWrapper<TResult, int, bool>> Where(Func<TResult, int, bool> predicate)
            => ValueEnumerableExtensions.Where<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, IFunction<TResult, int, bool>
                => ValueEnumerableExtensions.WhereAt<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, FunctionWrapper<TResult, bool>> Where(System.Func<TResult, bool> predicate)
                => ValueEnumerableExtensions.Where<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate> Where<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, IFunction<TResult, bool>
                => ValueEnumerableExtensions.Where<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(this, predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, FunctionWrapper<TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            => ValueEnumerableExtensions.Select<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
            => ValueEnumerableExtensions.Select<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectAtEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, FunctionWrapper<TResult, int, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
            => ValueEnumerableExtensions.Select<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectAtEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
            => ValueEnumerableExtensions.SelectAt<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2>(this, selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => this.ElementAt<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(index);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => this.First<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => this.Single<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.AsyncValueEnumerableWrapper<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> AsAsyncValueEnumerable()
                => ValueEnumerableExtensions.AsAsyncValueEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this);

            #endregion
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SkipEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> Skip(int count)
                => ValueEnumerableExtensions.Skip<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.TakeEnumerable<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> Take(int count)
                => ValueEnumerableExtensions.Take<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, count);

            #endregion
*/            
        }
 /*       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int, TSelector> source)
            where TSubEnumerable : IValueEnumerable<int, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<int>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int, TSelector>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<int?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<int?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int?, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, int?, TSelector>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long, TSelector> source)
            where TSubEnumerable : IValueEnumerable<long, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<long>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long, TSelector>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<long?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<long?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long?, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, long?, TSelector>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float, TSelector> source)
            where TSubEnumerable : IValueEnumerable<float, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<float>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float, TSelector>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<float?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<float?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float?, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, float?, TSelector>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double, TSelector> source)
            where TSubEnumerable : IValueEnumerable<double, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<double>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double, TSelector>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<double?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<double?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double?, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, double?, TSelector>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal, TSelector> source)
            where TSubEnumerable : IValueEnumerable<decimal, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<decimal>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal, TSelector>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSubEnumerable, TSubEnumerator, TSelector>(this SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal?, TSelector> source)
            where TSubEnumerable : IValueEnumerable<decimal?, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<decimal?>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.Sum<SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal?, TSelector>, SpanSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, decimal?, TSelector>.Enumerator, decimal?, decimal>();
*/
    }
}

