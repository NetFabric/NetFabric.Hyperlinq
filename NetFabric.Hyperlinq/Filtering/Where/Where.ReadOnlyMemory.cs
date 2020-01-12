using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static WhereEnumerable<TSource> Where<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate);
        }

        public readonly struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal WhereEnumerable(in ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public ref struct Enumerator 
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Span;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source[index];

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

            public struct DisposableEnumerator 
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly Predicate<TSource> predicate;
                int index;

                internal DisposableEnumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                [MaybeNull] public readonly TSource Current => source.Span[index];
                readonly object? IEnumerator.Current => source.Span[index];

                public bool MoveNext()
                {
                    while (++index < source.Length)
                    {
                        if (predicate(source.Span[index]))
                            return true;
                    }
                    return false;
                }

                public void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => source.Span.Count(predicate);

            public WhereSelectEnumerable<TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => WhereSelect<TSource, TResult>(source, predicate, selector);

            public TSource First()
                => source.Span.First(predicate);

            [return: MaybeNull]
            public TSource FirstOrDefault()
                => source.Span.FirstOrDefault(predicate);

            public TSource Single()
                => source.Span.Single(predicate);

            [return: MaybeNull]
            public TSource SingleOrDefault()
                => source.Span.SingleOrDefault(predicate);

            public void ForEach(Action<TSource> action)
                => SpanExtensions.ForEach<TSource>(source.Span, action, predicate);
            public void ForEach(Action<TSource, int> action)
                => SpanExtensions.ForEach<TSource>(source.Span, action, predicate);
        }
    }
}

