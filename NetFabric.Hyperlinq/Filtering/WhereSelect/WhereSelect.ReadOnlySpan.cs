using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        static SpanWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this ReadOnlySpan<TSource> source, 
            Predicate<TSource> predicate, 
            Selector<TSource, TResult> selector) 
            => new SpanWhereSelectEnumerable<TSource, TResult>(source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        public readonly ref struct SpanWhereSelectEnumerable<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly Predicate<TSource> predicate;
            internal readonly Selector<TSource, TResult> selector;

            internal SpanWhereSelectEnumerable(ReadOnlySpan<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                int index;

                internal Enumerator(in SpanWhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = -1;
                }

                public TResult Current 
                    => selector(source[index]);

                public bool MoveNext()
                {
                    while (++index < source.Length)
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

            public TResult[] ToArray()
                => Array.ToArray(source, predicate, selector);

            public List<TResult> ToList()
                => Array.ToList(source, predicate, selector);

            public void ForEach(Action<TResult> action)
                => source.ForEach(action, predicate, selector);
            public void ForEach(ActionAt<TResult> action)
                => source.ForEach(action, predicate, selector);
        }
    }
}

