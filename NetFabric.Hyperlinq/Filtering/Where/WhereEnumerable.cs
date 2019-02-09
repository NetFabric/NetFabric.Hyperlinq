using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource> 
            : IEnumerable<TSource>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;

            internal WhereEnumerable(in TEnumerable source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly Func<TSource, bool> predicate;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                }

                public TSource Current => enumerator.Current;
                object IEnumerator.Current => enumerator.Current;

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return true;
                    }
                    return false;
                }

                public void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            public Enumerable.SelectEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => Enumerable.Select<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult>(this, selector);

            public Enumerable.WhereEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Where(Func<TSource, bool> predicate) 
                => Enumerable.Where<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource First() 
                => Enumerable.First<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate) 
                => Enumerable.First<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => Enumerable.FirstOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => Enumerable.FirstOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single() 
                => Enumerable.Single<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => Enumerable.Single<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => Enumerable.SingleOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => Enumerable.SingleOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public IEnumerable<TSource> ToEnumerable()
                => this;

            public TSource[] ToArray()
                => Enumerable.ToArray<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
                => Enumerable.ToList<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
        }
    }

    static class WhereEnumerableExtensions
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this Enumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            => Enumerable.Count<Enumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);
    }
}

