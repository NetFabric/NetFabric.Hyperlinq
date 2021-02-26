using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TSubEnumerable>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>(this TList source, Func<TSource, TSubEnumerable> selector)
            where TList : struct, IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>(selector, 0, source.Count);

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TSubEnumerable>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult>(this TList source, Func<TSource, TSubEnumerable> selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>>(new FunctionWrapper<TSource, TSubEnumerable>(selector), offset, count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(this TList source, TSelector selector)
            where TList : struct, IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => new(source, selector, offset, count);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>
            : IValueEnumerable<TResult, SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator>
            where TList : struct, IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
        {
            readonly TList source;
            readonly TSelector selector;
            readonly int offset;
            readonly int count;

            internal SelectManyEnumerable(TList source, TSelector selector, int offset, int count)
                => (this.source, this.selector, this.offset, this.count) = (source, selector, offset, count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TList source;
                TSelector selector;
                readonly int end;
                EnumeratorState state;
                int sourceIndex;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly

                internal Enumerator(in SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    state = EnumeratorState.Enumerating;
                    sourceIndex = enumerable.offset;
                    end = sourceIndex + enumerable.count;
                    subEnumerator = default;
                }

                public readonly TResult Current
                    => subEnumerator.Current;
                readonly TResult IEnumerator<TResult>.Current 
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
                    => Throw.NotSupportedException();

                public void Dispose() => subEnumerator.Dispose();
            }


            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => this.Count<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => this.Any<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(Func<TResult, bool> predicate)
                => this.Any<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TResult, bool>
                => this.Any<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(Func<TResult, int, bool> predicate)
                => this.Any<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IFunction<TResult, int, bool>
                => this.AnyAt<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, FunctionWrapper<TResult, int, bool>> Where(Func<TResult, int, bool> predicate)
            => ValueEnumerableExtensions.Where<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, IFunction<TResult, int, bool>
                => ValueEnumerableExtensions.WhereAt<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, FunctionWrapper<TResult, bool>> Where(System.Func<TResult, bool> predicate)
                => ValueEnumerableExtensions.Where<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate> Where<TPredicate>(TPredicate predicate = default)
            where TPredicate : struct, IFunction<TResult, bool>
                => ValueEnumerableExtensions.Where<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TPredicate>(this, predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, FunctionWrapper<TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            => ValueEnumerableExtensions.Select<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
            => ValueEnumerableExtensions.Select<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectAtEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, FunctionWrapper<TResult, int, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
            => ValueEnumerableExtensions.Select<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectAtEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
            => ValueEnumerableExtensions.SelectAt<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult, TResult2, TSelector2>(this, selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => this.ElementAt<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(index);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => this.First<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => this.Single<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>();

            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.AsyncValueEnumerableWrapper<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> AsAsyncValueEnumerable()
                => ValueEnumerableExtensions.AsAsyncValueEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this);

            #endregion
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SkipEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> Skip(int count)
                => ValueEnumerableExtensions.Skip<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.TakeEnumerable<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult> Take(int count)
                => ValueEnumerableExtensions.Take<SelectManyEnumerable<TList, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, Enumerator, TResult>(this, count);

            #endregion
        }
    }
}

