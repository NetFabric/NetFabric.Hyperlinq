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
            if(getEnumerator is null) ThrowHelper.ThrowArgumentNullException(nameof(getEnumerator));

            return new CreateEnumerable<TEnumerator, TSource>(getEnumerator);
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
                => Count<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);

            public int Count(Func<TSource, bool> predicate)
                => Count<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

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

            public TSource[] ToArray()
                => ToArray<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ToList<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerator, TSource>(this CreateEnumerable<TEnumerator, TSource> source)
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => Enumerable.FirstOrNull<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerator, TSource>(this CreateEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate)
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => Enumerable.FirstOrNull<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerator, TSource>(this CreateEnumerable<TEnumerator, TSource> source)
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => Enumerable.SingleOrNull<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerator, TSource>(this CreateEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate)
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => Enumerable.SingleOrNull<CreateEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(source, predicate);
    }
}
