using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        internal static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, int, bool> predicate,
            Func<TSource, int, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector);
        }

        public readonly struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, int, bool> predicate;
            readonly Func<TSource, int, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, Func<TSource, int, bool> predicate, Func<TSource, int, TResult> selector)
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
                readonly Func<TSource, int, bool> predicate;
                readonly Func<TSource, int, TResult> selector;
                TSource current;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetValueEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    current = default;
                    index = 0;
                }

                public TResult Current => selector(current, index);

                public bool MoveNext()
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        checked
                        {
                            if (predicate(current, index))
                                return true;

                            index++;
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
                readonly Func<TSource, int, bool> predicate;
                readonly Func<TSource, int, TResult> selector;
                int index;

                internal ValueEnumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetValueEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = 0;
                }

                public bool TryMoveNext(out TResult current)
                {
                    while (enumerator.TryMoveNext(out var temp))
                    {
                        checked
                        {
                            if (predicate(temp, index))
                            {
                                current = selector(temp, index);
                                return true;
                            }

                            index++;
                        }
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        checked
                        {
                            if (predicate(current, index))
                                return true;

                            index++;
                        }
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);

            public int Count(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Count<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Skip(int count)
                => ValueEnumerable.Skip<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Take(int count)
                => ValueEnumerable.Take<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public bool All(Func<TResult, int, bool> predicate)
                => ValueEnumerable.All<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);

            public bool Any(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Any<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, int, TSelectorResult> selector)
                => ValueEnumerable.Select<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Where<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, int, bool> predicate)
                => ValueEnumerable.First<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, int, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Single<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, int, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

