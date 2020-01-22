﻿using System;
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
        public static SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            SelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectIndexEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectIndexEnumerable<,,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IValueEnumerable<TResult, SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly SelectorAt<TSource, TResult> selector;

            internal SelectIndexEnumerable(in TEnumerable source, SelectorAt<TSource, TResult> selector)
            {
                this.source = source;
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
                readonly SelectorAt<TSource, TResult> selector;
                int index;

                internal Enumerator(in SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(enumerator.Current, index);
                }
                readonly object? IEnumerator.Current => selector(enumerator.Current, index);

                public bool MoveNext()
                {
                    if (enumerator.MoveNext())
                    {
                        checked { index++; }
                        return true;
                    }
                    Dispose();
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long LongCount()
                => ValueEnumerable.LongCount<TEnumerable, TEnumerator, TSource>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Selector<TResult, TSelectorResult> selector)
                => ValueEnumerable.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerable.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(SelectorAt<TResult, TSelectorResult> selector)
                => ValueEnumerable.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(ValueEnumerable.First<TEnumerable, TEnumerator, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult FirstOrDefault()
                => selector(ValueEnumerable.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(ValueEnumerable.Single<TEnumerable, TEnumerator, TSource>(source), 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult SingleOrDefault()
                => selector(ValueEnumerable.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);

            public List<TResult> ToList()
            {
                var list = new List<TResult>();

                using var enumerator = source.GetEnumerator();
                for (var index = 0; enumerator.MoveNext(); index++)
                    list.Add(selector(enumerator.Current, index));

                return list;
            }

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult result;
                using var enumerator = source.GetEnumerator();
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    result = selector(enumerator.Current, index);
                    dictionary.Add(keySelector(result), result);
                }

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);

                TResult result;
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        result = selector(enumerator.Current, index);
                        dictionary.Add(keySelector(result), elementSelector(result));
                    }
                }

                return dictionary;
            }

            public void ForEach(Action<TResult> action)
                => ValueEnumerable.ForEach<TEnumerable, TEnumerator, TSource, TResult>(source, action, selector);
            public void ForEach(ActionAt<TResult> action)
                => ValueEnumerable.ForEach<TEnumerable, TEnumerator, TSource, TResult>(source, action, selector);
        }
    }
}

