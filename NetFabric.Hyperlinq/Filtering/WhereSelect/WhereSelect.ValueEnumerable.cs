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
        static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Predicate<TSource> predicate,
            Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Predicate<TSource> predicate;
            readonly Selector<TSource, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
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
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(enumerator.Current);
                readonly object? IEnumerator.Current 
                    => selector(enumerator.Current);

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

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);

            public bool Any()
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
                
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => ValueEnumerable.Contains<TEnumerable, TEnumerator, TSource, TResult>(source, value, comparer, predicate, selector);

            public TResult ElementAt(int index)
                => ValueEnumerable.ElementAt<TEnumerable, TEnumerator, TSource, TResult>(source, index, predicate, selector);

            [return: MaybeNull]
            public TResult ElementAtOrDefault(int index)
                => ValueEnumerable.ElementAtOrDefault<TEnumerable, TEnumerator, TSource, TResult>(source, index, predicate, selector);

            public TResult First()
                => ValueEnumerable.First<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            [return: MaybeNull]
            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public TResult Single()
                => ValueEnumerable.Single<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            [return: MaybeNull]
            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult result;
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    if (predicate(item))
                    {
                        result = selector(item);
                        dictionary.Add(keySelector(result), result);
                    }
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
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    if (predicate(item))
                    {
                        result = selector(item);
                        dictionary.Add(keySelector(result), elementSelector(result));
                    }
                }

                return dictionary;
            }

            public void ForEach(Action<TResult> action)
                => ValueEnumerable.ForEach<TEnumerable, TEnumerator, TSource, TResult>(source, action, predicate, selector);
            public void ForEach(ActionAt<TResult> action)
                => ValueEnumerable.ForEach<TEnumerable, TEnumerator, TSource, TResult>(source, action, predicate, selector);
        }
    }
}

