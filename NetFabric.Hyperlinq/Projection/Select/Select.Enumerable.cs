using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IEnumerable<TSource> 
            where TEnumerator : IEnumerator<TSource> 
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectEnumerable<,,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueEnumerable<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                }

                public TResult Current
                    => selector(enumerator.Current);

                public bool MoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }

            public long Count()
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source);
            public long Count(Func<TResult, bool> predicate)
                => ValueEnumerable.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Any()
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source);

            public Enumerable.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => Enumerable.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            public TResult First()
                => selector(Enumerable.First<TEnumerable, TEnumerator, TSource>(source));
            public TResult FirstOrDefault()
                => selector(Enumerable.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source));

            public TResult Single()
                => selector(Enumerable.Single<TEnumerable, TEnumerator, TSource>(source));
            public TResult SingleOrDefault()
                => selector(Enumerable.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source));
        }
    }
}
