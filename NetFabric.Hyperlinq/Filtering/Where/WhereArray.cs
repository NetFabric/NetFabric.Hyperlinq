using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static WhereArray<TSource> Where<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();

            return new WhereArray<TSource>(source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public readonly struct WhereArray<TSource> 
            : IEnumerable<TSource>
        {
            readonly TSource[] source;
            readonly Func<TSource, bool> predicate;

            internal WhereArray(TSource[] source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereArray<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public ref readonly TSource Current => ref source[index];
                TSource IEnumerator<TSource>.Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }

                public void Reset() => index = -1;

                public void Dispose() { }
            }

            public Enumerable.SelectEnumerable<WhereArray<TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) =>
                Enumerable.Select<WhereArray<TSource>, Enumerator, TSource, TResult>(this, selector);

            public Enumerable.WhereEnumerable<WhereArray<TSource>, Enumerator, TSource> Where(Func<TSource, bool> predicate) =>
                Enumerable.Where<WhereArray<TSource>, Enumerator, TSource>(this, predicate);

            public TSource First() 
                => Enumerable.First<WhereArray<TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate) 
                => Enumerable.First<WhereArray<TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => Enumerable.FirstOrDefault<WhereArray<TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => Enumerable.FirstOrDefault<WhereArray<TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single() 
                => Enumerable.Single<WhereArray<TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => Enumerable.Single<WhereArray<TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => Enumerable.SingleOrDefault<WhereArray<TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => Enumerable.SingleOrDefault<WhereArray<TSource>, Enumerator, TSource>(this, predicate);
        }
    }

    static class WhereArrayExtensions
    {
        public static int Count<TSource>(this Array.WhereArray<TSource> source)
            => Enumerable.Count<Array.WhereArray<TSource>, Array.WhereArray<TSource>.Enumerator, TSource>(source);
    }
}

