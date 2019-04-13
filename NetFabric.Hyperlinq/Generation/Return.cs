using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReturnEnumerable<TSource> Return<TSource>(TSource value) =>
            new ReturnEnumerable<TSource>(value);

        public readonly struct ReturnEnumerable<TSource>
            : IValueReadOnlyList<TSource, ReturnEnumerable<TSource>.ValueEnumerator>
        {
            internal readonly TSource value;

            internal ReturnEnumerable(TSource value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count => 1;

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

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
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

                internal ValueEnumerator(in ReturnEnumerable<TSource> enumerable)
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

            public bool All(Func<TSource, bool> predicate)
                => predicate(value);

            public bool Any()
                => true;

            public bool Any(Func<TSource, bool> predicate)
                => predicate(value);

            public bool Contains(TSource value)
                => this.value.Equals(value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => comparer.Equals(this.value, value);

            public ValueReadOnlyList.SelectEnumerable<ReturnEnumerable<TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => ValueReadOnlyList.Select<ReturnEnumerable<TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueReadOnlyList.SelectManyEnumerable<ReturnEnumerable<TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueReadOnlyList.SelectMany<ReturnEnumerable<TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<ReturnEnumerable<TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Where<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First() 
                => value;
            public TSource First(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.First<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => value;
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single() 
                => value;
            public TSource Single(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Single<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => value;
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IReadOnlyList<TSource> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public ReturnEnumerable<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueReadOnlyList.ToArray<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueReadOnlyCollection.ToList<ReturnEnumerable<TSource>, ValueEnumerator, TSource>(this);
        }

        public static int Count<TSource>(this ReturnEnumerable<TSource> source)
            => 1;

        public static int Count<TSource>(this ReturnEnumerable<TSource> source, Func<TSource, bool> predicate)
            => predicate(source.value) ? 1 : 0;

        public static TSource? FirstOrNull<TSource>(this ReturnEnumerable<TSource> source)
            where TSource : struct
                => source.value;

        public static TSource? FirstOrNull<TSource>(this ReturnEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
                => source.value;

        public static TSource? SingleOrNull<TSource>(this ReturnEnumerable<TSource> source)
            where TSource : struct
                => source.value;

        public static TSource? SingleOrNull<TSource>(this ReturnEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
                => source.value;
    }
}

