using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        internal static WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, Func<TSource, bool> predicate,
            Func<TSource, TResult> selector) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();
            if (selector is null) ThrowSelectorNull();

            return new WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public readonly struct WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;

            internal WhereSelectReadOnlyList(in TEnumerable source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public TResult Current => selector(source[index]);

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                        {
                            return true;
                        }

                        index++;
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public bool TryMoveNext(out TResult current)
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                        {
                            current = selector(source[index]);
                            return true;
                        }

                        index++;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public int Count()
            {
                var where = ReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate);
                return ValueEnumerable.Count<ReadOnlyList.WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ReadOnlyList.WhereReadOnlyList<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(where);
            }
    
            public ValueEnumerable.SelectValueEnumerable<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueEnumerable.Select<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereValueEnumerable<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueEnumerable.Where<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueEnumerable.First<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueEnumerable.Single<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<WhereSelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }
    }
}

