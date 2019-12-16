using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this Span<TSource> source, 
            Predicate<TSource> predicate, 
            Selector<TSource, TResult> selector) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector);
        }

        public readonly ref struct WhereSelectEnumerable<TSource, TResult>
        {
            internal readonly Span<TSource> source;
            internal readonly Predicate<TSource> predicate;
            internal readonly Selector<TSource, TResult> selector;

            internal WhereSelectEnumerable(Span<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                readonly Span<TSource> source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current 
                    => selector(source[index]);

                public bool MoveNext()
                {
                    while (++index < count)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public int Count()
                => source.Count(predicate);

            public TResult First()
                => selector(source.First(predicate));

            [return: MaybeNull]
            public TResult FirstOrDefault()
                => selector(source.FirstOrDefault(predicate));

            public TResult Single()
                => selector(source.Single(predicate));

            [return: MaybeNull]
            public TResult SingleOrDefault()
                => selector(source.SingleOrDefault(predicate));
        }
    }
}

