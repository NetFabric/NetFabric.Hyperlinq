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
        public static WhereEnumerable<TList, TSource> Where<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TList, TSource>(in source, predicate, 0, source.Count);
        }

        [Pure]
        static WhereEnumerable<TList, TSource> Where<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new WhereEnumerable<TList, TSource>(in source, predicate, skipCount, takeCount);

        public readonly partial struct WhereEnumerable<TList, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TList, TSource>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly Predicate<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(in TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereEnumerable<TList, TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TList source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => ReadOnlyList.Count<TList, TSource>(source, predicate, skipCount, takeCount);
                
            public bool Any()
                => ReadOnlyList.Any<TList, TSource>(source, predicate, skipCount, takeCount);
                
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => ReadOnlyList.Contains<TList, TSource>(source, value, comparer, predicate, skipCount, takeCount);

            public ReadOnlyList.WhereSelectEnumerable<TList, TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => ReadOnlyList.WhereSelect<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public ReadOnlyList.WhereEnumerable<TList, TSource> Where(Predicate<TSource> predicate)
                => ReadOnlyList.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public ReadOnlyList.WhereIndexEnumerable<TList, TSource> Where(PredicateAt<TSource> predicate)
                => ReadOnlyList.Where<TList, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public TSource ElementAt(int index)
                => ReadOnlyList.ElementAt<TList, TSource>(source, index, predicate, skipCount, takeCount);

            [return: MaybeNull]
            public TSource ElementAtOrDefault(int index)
                => ReadOnlyList.ElementAtOrDefault<TList, TSource>(source, index, predicate, skipCount, takeCount);

            public TSource First()
                => ReadOnlyList.First<TList, TSource>(source, predicate, skipCount, takeCount);

            [return: MaybeNull]
            public TSource FirstOrDefault()
                => ReadOnlyList.FirstOrDefault<TList, TSource>(source, predicate, skipCount, takeCount);

            public TSource Single()
                => ReadOnlyList.Single<TList, TSource>(source, predicate, skipCount, takeCount);

            [return: MaybeNull]
            public TSource SingleOrDefault()
                => ReadOnlyList.SingleOrDefault<TList, TSource>(source, predicate, skipCount, takeCount);

            public TSource[] ToArray()
                => ReadOnlyList.ToArray<TList, TSource>(source, predicate, skipCount, takeCount);

            public List<TSource> ToList()
                => ReadOnlyList.ToList<TList, TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => ReadOnlyList.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);

            public void ForEach(Action<TSource> action)
                => ReadOnlyList.ForEach<TList, TSource>(source, action, predicate, skipCount, takeCount);
            public void ForEach(ActionAt<TSource> action)
                => ReadOnlyList.ForEach<TList, TSource>(source, action, predicate, skipCount, takeCount);
        }
    }
}

