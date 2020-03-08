using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SkipTakeEnumerable<TList, TSource> SkipTake<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new SkipTakeEnumerable<TList, TSource>(in source, skipCount, takeCount);

        public readonly partial struct SkipTakeEnumerable<TList, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TList, TSource>.Enumerator>
            , IList<TSource>
            where TList : notnull, IReadOnlyList<TSource>
        {
            internal readonly TList source;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal SkipTakeEnumerable(in TList source, int skipCount, int takeCount)
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

            [MaybeNull]
            TSource IList<TSource>.this[int index]
            {
                get => this[index];
                set => throw new NotImplementedException();
            }

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
            {
                for (var index = 0; index < takeCount; index++)
                    array[index + arrayIndex] = source[index + skipCount];
            }
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotImplementedException();
            void ICollection<TSource>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => ReadOnlyList.Contains<TList, TSource>(source, item, null, skipCount, takeCount);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotImplementedException();
            int IList<TSource>.IndexOf(TSource item)
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                        return index;
                }
                return -1;
            }
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotImplementedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotImplementedException();

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TList, TSource> enumerable)
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

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TList, TSource> Take(int count)
                => ReadOnlyList.SkipTake<TList, TSource>(source, skipCount, Math.Min(takeCount, count));

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate)
                => ReadOnlyList.All<TList, TSource>(source, predicate, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(PredicateAt<TSource> predicate)
                => ReadOnlyList.All<TList, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ReadOnlyList.Any<TList, TSource>(source, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Predicate<TSource> predicate)
                => ReadOnlyList.Any<TList, TSource>(source, predicate, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(PredicateAt<TSource> predicate)
                => ReadOnlyList.Any<TList, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => ReadOnlyList.Contains<TList, TSource>(source, value, comparer, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.WhereEnumerable<TList, TSource> Where(Predicate<TSource> predicate)
                => ReadOnlyList.Where<TList, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.WhereIndexEnumerable<TList, TSource> Where(PredicateAt<TSource> predicate)
                => ReadOnlyList.Where<TList, TSource>(source, predicate, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TList, TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => ReadOnlyList.Select<TList, TSource, TResult>(source, selector, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectIndexEnumerable<TList, TSource, TResult> Select<TResult>(SelectorAt<TSource, TResult> selector)
                => ReadOnlyList.Select<TList, TSource, TResult>(source, selector, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource ElementAt(int index)
                => ReadOnlyList.ElementAt<TList, TSource>(source, index, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource ElementAtOrDefault(int index)
                => ReadOnlyList.ElementAtOrDefault<TList, TSource>(source, index, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First()
                => ReadOnlyList.First<TList, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource FirstOrDefault()
                => ReadOnlyList.FirstOrDefault<TList, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single()
                => ReadOnlyList.Single<TList, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault()
                => ReadOnlyList.SingleOrDefault<TList, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ToArray<TList, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ToList<TList, TSource>(source, skipCount, takeCount);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, skipCount, takeCount);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(Action<TSource> action)
                => ReadOnlyList.ForEach<TList, TSource>(source, action, skipCount, takeCount);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(ActionAt<TSource> action)
                => ReadOnlyList.ForEach<TList, TSource>(source, action, skipCount, takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this SkipTakeEnumerable<TList, TSource> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this SkipTakeEnumerable<TList, TSource> source, Predicate<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ReadOnlyList.Count<TList, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this SkipTakeEnumerable<TList, TSource> source, PredicateAt<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ReadOnlyList.Count<TList, TSource>(source.source, predicate, source.skipCount, source.takeCount);
        }
    }
}