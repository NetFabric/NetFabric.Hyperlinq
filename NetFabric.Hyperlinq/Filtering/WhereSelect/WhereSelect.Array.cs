using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, bool> predicate, 
            Func<TSource, TResult> selector) 
            => new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector, 0, source.Length);

        [Pure]
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source,
            Func<TSource, bool> predicate,
            Func<TSource, TResult> selector,
            int skipCount, int takeCount)
            => new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector, skipCount, takeCount);

        public readonly struct WhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TSource, TResult>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereSelectEnumerable(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator<TResult, Enumerator>(new Enumerator(in this));
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator<TResult, Enumerator>(new Enumerator(in this));

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index]);
                }

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

            public int Count()
                => Array.Count<TSource>(source, predicate, skipCount, takeCount);
            public int Count(Func<TSource, bool> predicate)
                => Array.Count<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public int Count(Func<TSource, int, bool> predicate)
                => Array.Count<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public bool Any()
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Func<TSource, bool> predicate)
                => Array.Any<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public bool Any(Func<TSource, int, bool> predicate)
                => Array.Any<TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public List<TResult> ToList()
            {
                var list = new List<TResult>();

                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        list.Add(selector(source[index]));
                }

                return list;
            }

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
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

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
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
        }
    }
}

