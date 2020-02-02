using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SkipTakeEnumerable<TSource> SkipTake<TSource>(this TSource[] source, int skipCount, int takeCount)
            => new SkipTakeEnumerable<TSource>(source, skipCount, takeCount);

        public readonly partial struct SkipTakeEnumerable<TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TSource>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal SkipTakeEnumerable(TSource[] source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
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
                readonly TSource[] source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TSource> enumerable)
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
            public SkipTakeEnumerable<TSource> Take(int count)
                => Array.SkipTake<TSource>(source, skipCount, Math.Min(takeCount, count));

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Array.Any<TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Predicate<TSource> predicate)
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(PredicateAt<TSource> predicate)
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.WhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Array.Where<TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.WhereIndexEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Array.Where<TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.SelectEnumerable<TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => Array.Select<TSource, TResult>(source, selector, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.SelectIndexEnumerable<TSource, TResult> Select<TResult>(SelectorAt<TSource, TResult> selector)
                => Array.Select<TSource, TResult>(source, selector, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource ElementAt(int index)
                => Array.ElementAt<TSource>(source, index, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource ElementAtOrDefault(int index)
                => Array.ElementAtOrDefault<TSource>(source, index, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Maybe<TSource> TryElementAt(int index)
                => Array.TryElementAt<TSource>(source, index, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ref readonly TSource First()
                => ref Array.First<TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ref readonly TSource First(Predicate<TSource> predicate)
                => ref Array.First<TSource>(source, predicate, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public ref readonly TSource FirstOrDefault(Predicate<TSource> predicate)
                => ref Array.FirstOrDefault<TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single()
                => Array.Single<TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single(Predicate<TSource> predicate)
                => Array.Single<TSource>(source, predicate, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault()
                => Array.SingleOrDefault<TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault(Predicate<TSource> predicate)
                => Array.SingleOrDefault<TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ToArray<TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => Array.ToList<TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, comparer, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(Action<TSource> action)
                => Array.ForEach<TSource>(source, action, skipCount, takeCount);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(ActionAt<TSource> action)
                => Array.ForEach<TSource>(source, action, skipCount, takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Array.Count<TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Array.Count<TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }
    }
}