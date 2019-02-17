using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyCollection<TResult, SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectValueReadOnlyCollection(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => source.Count();

            public struct Enumerator 
                : IDisposable
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;
                TSource current;

                internal Enumerator(in SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetValueEnumerator();
                    selector = enumerable.selector;
                    current = default;
                }

                public TResult Current => selector(current);

                public bool MoveNext() => enumerator.TryMoveNext(out current);

                public void Dispose() => enumerator.Dispose();
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;

                internal ValueEnumerator(in SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetValueEnumerator();
                    selector = enumerable.selector;
                }

                public bool TryMoveNext(out TResult current)
                {
                    if (enumerator.TryMoveNext(out var temp))
                    {
                        current = selector(temp);
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => enumerator.TryMoveNext();

                public void Dispose() => enumerator.Dispose();
            }

            public ValueReadOnlyCollection.SelectValueReadOnlyCollection<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                 => ValueReadOnlyCollection.Select<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereValueEnumerable<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueEnumerable.Where<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueReadOnlyCollection.First<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueEnumerable.First<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueReadOnlyCollection.FirstOrDefault<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueReadOnlyCollection.Single<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueEnumerable.Single<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueReadOnlyCollection.SingleOrDefault<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyCollection<TResult> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public TResult[] ToArray()
                => ValueReadOnlyCollection.ToArray<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectValueReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }
    }
}

