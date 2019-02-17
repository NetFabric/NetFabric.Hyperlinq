using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RepeatCountValueReadOnlyList<TSource> Repeat<TSource>(TSource value, int count)
        {
            if (count < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            return new RepeatCountValueReadOnlyList<TSource>(value, count);
        }

        public readonly struct RepeatCountValueReadOnlyList<TSource>
            : IValueReadOnlyList<TSource, RepeatCountValueReadOnlyList<TSource>.ValueEnumerator>
        {
            readonly TSource value;
            readonly int count;

            internal RepeatCountValueReadOnlyList(TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => count;

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return value;
                }
            }

            public struct Enumerator 
            {
                readonly TSource value;
                int counter;

                internal Enumerator(in RepeatCountValueReadOnlyList<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                public TSource Current => value;

                public bool MoveNext() => counter-- > 0;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource value;
                int counter;

                internal ValueEnumerator(in RepeatCountValueReadOnlyList<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                public bool TryMoveNext(out TSource current)
                {
                    if (counter-- > 0)
                    {
                        current = value;
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => counter-- > 0;

                public void Dispose() { }
            }

            public ValueReadOnlyList.SelectValueReadOnlyList<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => ValueReadOnlyList.Select<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueReadOnlyList.WhereValueReadOnlyList<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Where<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First() 
                => ValueReadOnlyList.First<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.First<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => ValueReadOnlyList.FirstOrDefault<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.FirstOrDefault<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single() 
                => ValueReadOnlyList.Single<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Single<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => ValueReadOnlyList.SingleOrDefault<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyCollection<TSource> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyList<TSource> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => ValueReadOnlyList.ToArray<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueReadOnlyCollection.ToList<RepeatCountValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
        }
    }
 }

