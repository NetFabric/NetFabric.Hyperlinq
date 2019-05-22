using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        internal static WhereSelectEnumerable<TEnumerable, TSource, TResult> WhereSelect<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, bool> predicate,
            Func<TSource, TResult> selector) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TEnumerable, TSource, TResult>(in source, predicate, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(WhereSelectEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereSelectEnumerable<,,>.Enumerator))]
        public readonly struct WhereSelectEnumerable<TEnumerable, TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TSource, TResult>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
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

                public void Dispose() { }
            }

            public long Count()
                => ReadOnlyList.Count<TEnumerable, TSource>(source, predicate);

            public bool Any()
                => ReadOnlyList.Any<TEnumerable, TSource>(source, predicate);
        }
    }
}

