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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereIndexEnumerable<TSource> Where<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereIndexEnumerable<TSource>(source, predicate);
        }

        public readonly partial struct WhereIndexEnumerable<TSource>
            : IValueEnumerable<TSource, WhereIndexEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly PredicateAt<TSource> predicate;

            internal WhereIndexEnumerable(in ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereIndexEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public ref struct Enumerator 
            {
                readonly ReadOnlySpan<TSource> source;
                readonly PredicateAt<TSource> predicate;
                int index;

                internal Enumerator(in WhereIndexEnumerable<TSource> enumerable)
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
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator 
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly PredicateAt<TSource> predicate;
                int index;

                internal DisposableEnumerator(in WhereIndexEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                [MaybeNull] 
                public readonly TSource Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current 
                    => source.Span[index];

                public bool MoveNext()
                {
                    while (++index < source.Length)
                    {
                        if (predicate(source.Span[index], index))
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
            public void ForEach(ActionAt<TSource> action)
                => SpanExtensions.ForEach<TSource>(source.Span, action, predicate);
        }
    }
}

