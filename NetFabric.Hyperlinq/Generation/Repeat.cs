using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RepeatValueEnumerable<TSource> Repeat<TSource>(TSource value) =>
            new RepeatValueEnumerable<TSource>(value);

        public readonly struct RepeatValueEnumerable<TSource>
            : IValueEnumerable<TSource, RepeatValueEnumerable<TSource>.ValueEnumerator>
        {
            readonly TSource value;

            internal RepeatValueEnumerable(TSource value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public TSource this[int index] => value;

            public readonly struct Enumerator 
            {
                readonly TSource value;

                internal Enumerator(in RepeatValueEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                }

                public TSource Current => value;

                public bool MoveNext() => true;
            }

            public readonly struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource value;

                internal ValueEnumerator(in RepeatValueEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                }

                public bool TryMoveNext(out TSource current)
                {
                    current = value;
                    return true;
                }

                public bool TryMoveNext() => true;

                public void Dispose() { }
            }

            public int Count(Func<TSource, bool> predicate)
                => ValueEnumerable.Count<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ValueEnumerable.SelectValueEnumerable<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => ValueEnumerable.Select<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereValueEnumerable<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate) 
                => ValueEnumerable.Where<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First() 
                => ValueEnumerable.First<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate) 
                => ValueEnumerable.First<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => ValueEnumerable.FirstOrDefault<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => ValueEnumerable.FirstOrDefault<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single() 
                => ValueEnumerable.Single<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => ValueEnumerable.Single<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => ValueEnumerable.SingleOrDefault<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => ValueEnumerable.SingleOrDefault<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<RepeatValueEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToArray()
                => throw new NotSupportedException();

            public List<TSource> ToList()
                => throw new NotSupportedException();
        }
    }
}

