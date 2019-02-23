using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IReadOnlyCollection<TSource> 
            where TEnumerator : IEnumerator<TSource> 
        {
            if(source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyCollection<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => source.Count;

            public struct Enumerator 
                : IDisposable
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(enumerable.source);
                    selector = enumerable.selector;
                }

                public TResult Current => selector(enumerator.Current);

                public bool MoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;

                internal ValueEnumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(enumerable.source);
                    selector = enumerable.selector;
                }

                public bool TryMoveNext(out TResult current)
                {
                    if (enumerator.MoveNext())
                    {
                        current = selector(enumerator.Current);
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }

            public int Count(Func<TResult, bool> predicate)
                => ValueReadOnlyCollection.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool All(Func<TResult, bool> predicate)
                => ValueReadOnlyCollection.All<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => source.Count != 0;

            public bool Any(Func<TResult, bool> predicate)
                => ValueReadOnlyCollection.Any<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyCollection.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyCollection.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueReadOnlyCollection.SelectEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                 => ValueReadOnlyCollection.Select<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueEnumerable.Where<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueReadOnlyCollection.First<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueEnumerable.First<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueReadOnlyCollection.FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueReadOnlyCollection.Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueEnumerable.Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueReadOnlyCollection.SingleOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyCollection<TResult> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
                => this;

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueReadOnlyCollection()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyCollection.ToArray<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }
    }
}

