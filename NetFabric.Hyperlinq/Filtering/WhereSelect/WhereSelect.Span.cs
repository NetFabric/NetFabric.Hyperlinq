using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this Span<TSource> source, 
            Func<TSource, long, bool> predicate, 
            Func<TSource, long, TResult> selector) 
            => new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector);

        public readonly ref struct WhereSelectEnumerable<TSource, TResult>
        {
            internal readonly Span<TSource> source;
            internal readonly Func<TSource, long, bool> predicate;
            internal readonly Func<TSource, long, TResult> selector;

            internal WhereSelectEnumerable(Span<TSource> source, Func<TSource, long, bool> predicate, Func<TSource, long, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                readonly Span<TSource> source;
                readonly Func<TSource, long, bool> predicate;
                readonly Func<TSource, long, TResult> selector;
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
                    => selector(source[index], index);

                public bool MoveNext()
                {
                    while (++index < count)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }
            }

            public int Count()
                => source.Count(predicate);

            public TResult First()
                => selector(source.First(predicate, out var index), index);

            public TResult FirstOrDefault()
                => selector(source.FirstOrDefault(predicate, out var index), index);

            public TResult Single()
                => selector(source.Single(predicate, out var index), index);

            public TResult SingleOrDefault()
                => selector(source.SingleOrDefault(predicate, out var index), index);
        }

        public static TResult? FirstOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source)
            where TResult : struct
        {
            var span = source.source;
            var length = span.Length;
            for (var index = 0; index < length; index++)
            {
                if (source.predicate(span[index], index))
                    return source.selector(span[index], index);
            }
            return null;
        }

        public static TResult? SingleOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source)
            where TResult : struct
        {
            var span = source.source;
            var length = span.Length;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            for (var index = 0; index < length; index++)
            {
                if (source.predicate(span[index], index))
                    return source.selector(span[index], index);
            }
            return null;
        }
    }
}

