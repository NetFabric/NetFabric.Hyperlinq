using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReturnEnumerable<TSource> Return<TSource>(TSource value) =>
            new ReturnEnumerable<TSource>(value);

        public readonly struct ReturnEnumerable<TSource>
            : IValueReadOnlyList<TSource, ReturnEnumerable<TSource>.Enumerator>
        {
            internal readonly TSource value;

            internal ReturnEnumerable(TSource value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public long Count => 1;

            public TSource this[long index]
            {
                get
                {
                    if(index != 0) ThrowHelper.ThrowIndexOutOfRangeException();
                    
                    return value;
                }
            }

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource value;
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                public TSource Current
                    => value;

                public bool MoveNext()
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

            public ValueReadOnlyList.SkipTakeEnumerable<ReturnEnumerable<TSource>, Enumerator, TSource> Skip(int count)
                => ValueReadOnlyList.Skip<ReturnEnumerable<TSource>, Enumerator, TSource>(this, count);

            public ValueReadOnlyList.SkipTakeEnumerable<ReturnEnumerable<TSource>, Enumerator, TSource> Take(int count)
                => ValueReadOnlyList.Take<ReturnEnumerable<TSource>, Enumerator, TSource>(this, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.All<ReturnEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => true;

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Any<ReturnEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => EqualityComparer<TSource>.Default.Equals(this.value, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => comparer.Equals(this.value, value);

            public ValueReadOnlyList.SelectEnumerable<ReturnEnumerable<TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector) 
                => ValueReadOnlyList.Select<ReturnEnumerable<TSource>, Enumerator, TSource, TResult>(this, selector);

            public ValueReadOnlyList.SelectManyEnumerable<ReturnEnumerable<TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueReadOnlyList.SelectMany<ReturnEnumerable<TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<ReturnEnumerable<TSource>, Enumerator, TSource> Where(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.Where<ReturnEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource First() 
                => value;
            public TSource First(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.First<ReturnEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => value;
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<ReturnEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single() 
                => value;
            public TSource Single(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.Single<ReturnEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => value;
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<ReturnEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public IReadOnlyList<TSource> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<ReturnEnumerable<TSource>, Enumerator, TSource>(this);

            public ReturnEnumerable<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
            {
                var array = new TSource[1];
                array[0] = value;
                return array;
            }

            public List<TSource> ToList()
            {
                var list = new List<TSource>();
                list.Add(value);
                return list;
            }
        }

        public static long Count<TSource>(this ReturnEnumerable<TSource> source)
            => 1;
        public static long Count<TSource>(this ReturnEnumerable<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.Count<ReturnEnumerable<TSource>, ReturnEnumerable<TSource>.Enumerator, TSource>(source, predicate);
        public static long Count<TSource>(this ReturnEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            => ValueReadOnlyList.Count<ReturnEnumerable<TSource>, ReturnEnumerable<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource>(this ReturnEnumerable<TSource> source)
            where TSource : struct
                => source.value;

        public static TSource? FirstOrNull<TSource>(this ReturnEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
                => source.value;

        public static TSource? SingleOrNull<TSource>(this ReturnEnumerable<TSource> source)
            where TSource : struct
                => source.value;

        public static TSource? SingleOrNull<TSource>(this ReturnEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
                => source.value;
    }
}

