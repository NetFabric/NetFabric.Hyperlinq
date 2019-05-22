using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectEnumerable<,,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyCollection<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
 
            public long Count => source.Count;

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                }

                public TResult Current => selector(enumerator.Current);

                public bool MoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }

            public bool Any()
                => source.Count != 0;

            public ValueReadOnlyCollection.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueReadOnlyCollection.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            public TResult First()
                => selector(ValueReadOnlyCollection.First<TEnumerable, TEnumerator, TSource>(source));
            public TResult FirstOrDefault()
                => selector(ValueReadOnlyCollection.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source));

            public TResult Single()
                => selector(ValueReadOnlyCollection.Single<TEnumerable, TEnumerator, TSource>(source));
            public TResult SingleOrDefault()
                => selector(ValueReadOnlyCollection.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source));
        }
    }
}

