﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static WhereEnumerable<TSource> Where<TSource>(this Span<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate);
        }

        public readonly ref struct WhereEnumerable<TSource>
        {
            internal readonly Span<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal WhereEnumerable(in Span<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator 
            {
                readonly Span<TSource> source;
                readonly Predicate<TSource> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                [MaybeNull]
                public ref TSource Current => ref source[index];

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

            public WhereSelectEnumerable<TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => WhereSelect<TSource, TResult>(source, predicate, selector);

            public TSource First()
                => source.First(predicate);

            [return: MaybeNull]
            public TSource FirstOrDefault()
                => source.FirstOrDefault(predicate);

            public TSource Single()
                => source.Single(predicate);

            [return: MaybeNull]
            public TSource SingleOrDefault()
                => source.SingleOrDefault(predicate);

            public void ForEach(Action<TSource> action)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                        action(source[index]);
                }
            }
            public void ForEach(Action<TSource, int> action)
            {
                var actionIndex = 0;
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                        action(source[index], actionIndex++);
                }
            }
        }
    }
}

