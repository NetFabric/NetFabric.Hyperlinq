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
        static WhereSelectEnumerable<TList, TSource, TResult> WhereSelect<TList, TSource, TResult>(
            this TList source, 
            Predicate<TSource> predicate,
            Selector<TSource, TResult> selector)
            where TList : notnull, IReadOnlyList<TSource>
            => new WhereSelectEnumerable<TList, TSource, TResult>(in source, predicate, selector, 0, source.Count);

        [Pure]
        static WhereSelectEnumerable<TList, TSource, TResult> WhereSelect<TList, TSource, TResult>(
            this TList source,
            Predicate<TSource> predicate,
            Selector<TSource, TResult> selector, 
            int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new WhereSelectEnumerable<TList, TSource, TResult>(in source, predicate, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct WhereSelectEnumerable<TList, TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly Predicate<TSource> predicate;
            readonly Selector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereSelectEnumerable(in TList source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, WhereSelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TList source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TResult Current
                    => selector(source[index]);

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
                : IEnumerator<TResult>
            {
                readonly TList source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereSelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index]);
                readonly object? IEnumerator.Current 
                    => selector(source[index]);

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
                
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => ReadOnlyList.Contains<TList, TSource, TResult>(source, value, comparer, predicate, selector, skipCount, takeCount);

            public TResult ElementAt(int index)
                => ReadOnlyList.ElementAt<TList, TSource, TResult>(source, index, predicate, selector, skipCount, takeCount);

            [return: MaybeNull]
            public TResult ElementAtOrDefault(int index)
                => ReadOnlyList.ElementAtOrDefault<TList, TSource, TResult>(source, index, predicate, selector, skipCount, takeCount);

            public TResult First()
                => ReadOnlyList.First<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            [return: MaybeNull]
            public TResult FirstOrDefault()
                => ReadOnlyList.FirstOrDefault<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public TResult Single()
                => ReadOnlyList.Single<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            [return: MaybeNull]
            public TResult SingleOrDefault()
                => ReadOnlyList.SingleOrDefault<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public TResult[] ToArray()
                => ReadOnlyList.ToArray<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount); 

            public List<TResult> ToList()
                => ReadOnlyList.ToList<TList, TSource, TResult>(source, predicate, selector, skipCount, takeCount); 

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                    {
                        item = selector(source[index]);
                        dictionary.Add(keySelector(item), item);
                    }
                }

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                    {
                        item = selector(source[index]);
                        dictionary.Add(keySelector(item), elementSelector(item));
                    }
                }

                return dictionary;
            }

            public void ForEach(Action<TResult> action)
                => ReadOnlyList.ForEach<TList, TSource, TResult>(source, action, predicate, selector, skipCount, takeCount);
            public void ForEach(ActionAt<TResult> action)
                => ReadOnlyList.ForEach<TList, TSource, TResult>(source, action, predicate, selector, skipCount, takeCount);
        }
    }
}

