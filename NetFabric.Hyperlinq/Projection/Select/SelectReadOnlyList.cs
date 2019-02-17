using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectReadOnlyList<TEnumerable, TSource, TResult> Select<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IReadOnlyList<TSource> 
        {
            if(source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectReadOnlyList<TEnumerable, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectReadOnlyList<TEnumerable, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectReadOnlyList<TEnumerable, TSource, TResult>.ValueEnumerator>
           where TEnumerable : IReadOnlyList<TSource> 
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectReadOnlyList(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => source.Count;

            public TResult this[int index] => selector(source[index]);

            public struct Enumerator 
            {
                readonly TEnumerable source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in SelectReadOnlyList<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public TResult Current => selector(source[index]);

                public bool MoveNext() => ++index < count;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal ValueEnumerator(in SelectReadOnlyList<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public bool TryMoveNext(out TResult current)
                {
                    index++;
                    if (index < count)
                    {
                        current = selector(source[index]);
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++index < count;

                public void Dispose() { }
            }

            public ValueReadOnlyList.SelectValueReadOnlyList<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                 => ValueReadOnlyList.Select<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueReadOnlyList.WhereValueReadOnlyList<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Where<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueReadOnlyList.First<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueReadOnlyList.First<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueReadOnlyList.FirstOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueReadOnlyList.Single<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Single<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueReadOnlyList.SingleOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyCollection<TResult> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyList<TResult> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public TResult[] ToArray()
                => ValueReadOnlyList.ToArray<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectReadOnlyList<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

        }
    }
}

