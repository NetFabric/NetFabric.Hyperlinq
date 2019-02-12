using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        internal static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, bool> predicate,
            Func<TSource, TResult> selector)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();
            if (selector is null) ThrowSelectorNull();

            return new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public readonly struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
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

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator 
                : IDisposable
            {
                TEnumerator enumerator;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                TResult current;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    current = default;
                }

                public TResult Current => current;

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                        {
                            current = selector(enumerator.Current);
                            return true;
                        }
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose();
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;

                internal ValueEnumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                }

                public bool TryMoveNext(out TResult current)
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                        {
                            current = selector(enumerator.Current);
                            return true;
                        }
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return true;
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose();
            }

            public int Count()
            {
                var where = Enumerable.Where<TEnumerable, TEnumerator, TSource>(source, predicate);
                return ValueEnumerable.Count<Enumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(where);
            }

            public ValueEnumerable.SelectValueEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueEnumerable.Select<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereValueEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueEnumerable.Where<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueEnumerable.First<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueEnumerable.Single<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }
    }
}

