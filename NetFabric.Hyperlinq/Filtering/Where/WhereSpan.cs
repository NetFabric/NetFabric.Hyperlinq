using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static WhereEnumerable<TSource> Where<TSource>(this System.Span<TSource> source, Func<TSource, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate);
        }

        public readonly ref struct WhereEnumerable<TSource>
        {
            readonly Span<TSource> source;
            readonly Func<TSource, bool> predicate;

            internal WhereEnumerable(in Span<TSource> source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator 
            {
                readonly Span<TSource> source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public ref readonly TSource Current => ref source[index];

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }
            }

            public int Count()
                => source.Count(predicate);

            public WhereSelectEnumerable<TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => WhereSelect<TSource, TResult>(source, predicate, selector);

            public TSource First()
                => source.First(predicate);

            public TSource FirstOrDefault()
                => source.FirstOrDefault(predicate);

            public TSource Single()
                => source.Single(predicate);

            public TSource SingleOrDefault()
                => source.SingleOrDefault(predicate);
        }
    }
}

