using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count
                => takeCount;

            [MaybeNull]
            public readonly TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount) 
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < end;

                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => ValueReadOnlyList.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Predicate<TSource> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Predicate<TSource> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TResult>(source, selector, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueReadOnlyList.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(SelectorAt<TSource, TResult> selector)
                => ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TResult>(source, selector, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource ElementAt(int index)
                => ValueReadOnlyList.ElementAt<TEnumerable, TEnumerator, TSource>(source, index, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource ElementAtOrDefault(int index)
                => ValueReadOnlyList.ElementAtOrDefault<TEnumerable, TEnumerator, TSource>(source, index, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Maybe<TSource> TryElementAt(int index)
                => ValueReadOnlyList.TryElementAt<TEnumerable, TEnumerator, TSource>(source, index, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).ThrowOnEmpty();
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource FirstOrDefault()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).DefaultOnEmpty();
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource FirstOrDefault(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (ElementResult Success, TSource Value) TryFirst()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (ElementResult Success, TSource Value) TryFirst(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single()
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).ThrowOnEmpty();
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault()
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount).DefaultOnEmpty();
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ToArray<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ToList<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(Action<TSource> action)
                => ValueReadOnlyList.ForEach<TEnumerable, TEnumerator, TSource>(source, action, skipCount, takeCount);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(ActionAt<TSource> action)
                => ValueReadOnlyList.ForEach<TEnumerable, TEnumerator, TSource>(source, action, skipCount, takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }
    }
}