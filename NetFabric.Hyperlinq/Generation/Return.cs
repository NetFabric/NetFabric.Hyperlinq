using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReturnValueReadOnlyList<TSource> Return<TSource>(TSource value) =>
            new ReturnValueReadOnlyList<TSource>(value);

        public readonly struct ReturnValueReadOnlyList<TSource>
            : IValueReadOnlyList<TSource, ReturnValueReadOnlyList<TSource>.ValueEnumerator>
        {
            readonly TSource value;

            internal ReturnValueReadOnlyList(TSource value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => 1;

            public TSource this[int index]
            {
                get
                {
                    if(index != 0) ThrowHelper.ThrowIndexOutOfRangeException();
                    
                    return value;
                }
            }

            public struct Enumerator
            {
                readonly TSource value;
                bool moveNext;

                internal Enumerator(in ReturnValueReadOnlyList<TSource> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                public TSource Current => value;

                public bool MoveNext()
                {
                    if(moveNext)
                    {
                        moveNext = false;
                        return true;
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource value;
                bool moveNext;

                internal ValueEnumerator(in ReturnValueReadOnlyList<TSource> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                public bool TryMoveNext(out TSource current)
                {
                    if (moveNext)
                    {
                        current = value;
                        moveNext = false;
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    if (moveNext)
                    {
                        moveNext = false;
                        return true;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public ValueReadOnlyList.SelectValueReadOnlyList<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => ValueReadOnlyList.Select<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueReadOnlyList.WhereValueReadOnlyList<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Where<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First() 
                => ValueReadOnlyList.First<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.First<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => ValueReadOnlyList.FirstOrDefault<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single() 
                => ValueReadOnlyList.Single<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Single<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => ValueReadOnlyList.SingleOrDefault<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyCollection<TSource> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyList<TSource> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => ValueReadOnlyList.ToArray<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueReadOnlyCollection.ToList<ReturnValueReadOnlyList<TSource>, ValueEnumerator, TSource>(this);
        }
    }
}

