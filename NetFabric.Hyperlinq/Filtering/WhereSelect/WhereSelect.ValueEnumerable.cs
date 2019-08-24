using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        internal static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, bool> predicate,
            Func<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(WhereSelectEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereSelectEnumerable<,,,>.Enumerator))]
        public readonly struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TResult>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(enumerator.Current);
                }
                readonly object IEnumerator.Current => selector(enumerator.Current);

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return true;
                    }
                    Dispose();
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);
            public int Count(Func<TSource, bool> predicate)
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));
            public int Count(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));

            public bool Any()
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool Any(Func<TSource, bool> predicate)
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));
            public bool Any(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));

            public List<TResult> ToList()
            {
                var list = new List<TResult>();

                foreach (var item in source)
                {
                    if (predicate(item))
                        list.Add(selector(item));
                }

                return list;
            }

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult result;
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        result = selector(item);
                        dictionary.Add(keySelector(result), result);
                    }
                }

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);

                TResult result;
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        result = selector(item);
                        dictionary.Add(keySelector(result), elementSelector(result));
                    }
                }

                return dictionary;
            }
        }
    }
}

