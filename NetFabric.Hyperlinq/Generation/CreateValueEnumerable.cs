using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
{
        public static CreateValueEnumerable<TEnumerator, TSource> Create<TEnumerator, TSource>(Func<TEnumerator> getEnumerator) 
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if(getEnumerator is null) ThrowHelper.ThrowArgumentNullException(nameof(getEnumerator));

            return new CreateValueEnumerable<TEnumerator, TSource>(getEnumerator);
        }

        public readonly struct CreateValueEnumerable<TEnumerator, TSource> 
            : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly Func<TEnumerator> getEnumerator;

            internal CreateValueEnumerable(Func<TEnumerator> getEnumerator)
            {
                this.getEnumerator = getEnumerator;
            }

            public TEnumerator GetValueEnumerator() => getEnumerator();

            public int Count()
                => Count<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);

            public int Count(Func<TSource, bool> predicate)
                => Count<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public SelectValueEnumerable<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => Select<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource, TResult>(this, selector);

            public WhereValueEnumerable<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource> Where(Func<TSource, bool> predicate) 
                => Where<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource First() 
                => First<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this); 
            public TSource First(Func<TSource, bool> predicate) 
                => First<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => FirstOrDefault<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => FirstOrDefault<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource Single() 
                => Single<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => Single<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => SingleOrDefault<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => SingleOrDefault<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this, predicate);

            public TSource[] ToArray()
                => ToArray<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ToList<CreateValueEnumerable<TEnumerator, TSource>, TEnumerator, TSource>(this);
        }
    }
}
