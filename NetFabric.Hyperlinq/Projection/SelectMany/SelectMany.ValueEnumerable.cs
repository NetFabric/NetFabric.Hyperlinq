using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TSubEnumerable>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this TEnumerable source, Func<TSource, TSubEnumerable> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.SelectMany<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>>(new FunctionWrapper<TSource, TSubEnumerable>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(this TEnumerable source, TSelector selector = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => new(source, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>
            : IValueEnumerable<TResult, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
        {
            readonly TEnumerable source;
            readonly TSelector selector;

            internal SelectManyEnumerable(in TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);
            
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
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator sourceEnumerator; // do not make readonly
                TSelector selector;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly
                int state;

                internal Enumerator(in SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> enumerable)
                {
                    sourceEnumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    subEnumerator = default;
                    state = 0;
                }

                public readonly TResult Current
                    => subEnumerator.Current;
                readonly TResult IEnumerator<TResult>.Current 
                    => subEnumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => subEnumerator.Current!;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (!sourceEnumerator.MoveNext())
                                break;

                            var enumerable = selector.Invoke(sourceEnumerator.Current);
                            subEnumerator = enumerable.GetEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.MoveNext())
                            {
                                state = 1;
                                goto case 1;
                            }
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() => subEnumerator.Dispose();
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => this.Count<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>();

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => this.Any<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(Func<TResult, bool> predicate)
                => this.Any<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TResult, bool>
                => this.Any<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate>(Func<TResult, int, bool> predicate)
                => this.Any<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate>(TPredicate predicate)
                where TPredicate : struct, IFunction<TResult, int, bool>
                => this.AnyAt<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TPredicate>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, FunctionWrapper<TResult, int, bool>> Where(Func<TResult, int, bool> predicate)
            => ValueEnumerableExtensions.Where<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TPredicate> WhereAt<TPredicate>(TPredicate predicate)
            where TPredicate : struct, IFunction<TResult, int, bool>
                => ValueEnumerableExtensions.WhereAt<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TPredicate>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, FunctionWrapper<TResult, bool>> Where(System.Func<TResult, bool> predicate)
                => ValueEnumerableExtensions.Where<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TPredicate> Where<TPredicate>(TPredicate predicate)
            where TPredicate : struct, IFunction<TResult, bool>
                => ValueEnumerableExtensions.Where<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TPredicate>(this, predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2, FunctionWrapper<TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            => ValueEnumerableExtensions.Select<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2, TSelector2> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
            => ValueEnumerableExtensions.Select<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2, TSelector2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectAtEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2, FunctionWrapper<TResult, int, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
            => ValueEnumerableExtensions.Select<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2>(this, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectAtEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2, TSelector2> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
            => ValueEnumerableExtensions.SelectAt<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult, TResult2, TSelector2>(this, selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => this.ElementAt<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(index);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => this.First<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => this.Single<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>();

            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.AsyncValueEnumerableWrapper<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult> AsAsyncValueEnumerable()
                => ValueEnumerableExtensions.AsAsyncValueEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(this);

            #endregion
            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SkipEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult> Skip(int count)
                => ValueEnumerableExtensions.Skip<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(this, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.TakeEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult> Take(int count)
                => ValueEnumerableExtensions.Take<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator, TResult>(this, count);

            #endregion
        }
    }
}

