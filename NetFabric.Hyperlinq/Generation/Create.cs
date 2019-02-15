using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static CreateEnumerable<TEnumerator, TSource> Create<TEnumerator, TSource>(Func<TEnumerator> getEnumerator) 
            where TEnumerator : IEnumerator<TSource>
        {
            if(getEnumerator is null) ThrowGetEnumeratorNull();

            return new CreateEnumerable<TEnumerator, TSource>(getEnumerator);

            void ThrowGetEnumeratorNull() => throw new ArgumentNullException(nameof(getEnumerator));
        }

        public readonly struct CreateEnumerable<TEnumerator, TSource> : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly Func<TEnumerator> getEnumerator;

            internal CreateEnumerable(Func<TEnumerator> getEnumerator)
            {
                this.getEnumerator = getEnumerator;
            }

            public TEnumerator GetEnumerator() => getEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => getEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => getEnumerator();

            public int Count()
                => Count<CreateEnumerable<TEnumerator, TSource>, TSource>(this);

            public SelectEnumerable<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => Select<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource, TResult>(this, selector);

            public WhereEnumerable<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource> Where(Func<TSource, bool> predicate) 
                => Where<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource First() 
                => First<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this); 
            public TSource First(Func<TSource, bool> predicate) 
                => First<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => FirstOrDefault<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => FirstOrDefault<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource Single() 
                => Single<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => Single<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => SingleOrDefault<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => SingleOrDefault<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => this;

            public TSource[] ToArray()
                => ToArray<CreateEnumerable<TEnumerator, TSource>, TSource>(this);

            public List<TSource> ToList()
                => ToList<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
        }
    }
}
