using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        internal static WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, bool> predicate,
            Func<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();
            if (selector is null) ThrowSelectorNull();

            return new WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public readonly struct WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;

            internal WhereSelectValueReadOnlyList(in TEnumerable source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
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
                TResult current;
                int index;

                internal Enumerator(in WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Count();
                    current = default;
                    index = -1;
                }

                public TResult Current => current;

                public bool MoveNext()
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
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Count();
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
                        {
                            return true;
                        }

                        index++;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public int Count()
            {
                var where = ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, predicate);
                return ValueEnumerable.Count<ValueReadOnlyList.WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueReadOnlyList.WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(where);
            }

            public ValueEnumerable.SelectValueEnumerable<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueEnumerable.Select<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereValueEnumerable<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueEnumerable.Where<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueEnumerable.First<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueEnumerable.Single<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<WhereSelectValueReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }
    }
}

