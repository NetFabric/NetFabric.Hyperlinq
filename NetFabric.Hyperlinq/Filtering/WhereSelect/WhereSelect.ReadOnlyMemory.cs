using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        static MemoryWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this ReadOnlyMemory<TSource> source, 
            Predicate<TSource> predicate, 
            Selector<TSource, TResult> selector) 
            => new MemoryWhereSelectEnumerable<TSource, TResult>(source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct MemoryWhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly Predicate<TSource> predicate;
            internal readonly Selector<TSource, TResult> selector;

            internal MemoryWhereSelectEnumerable(ReadOnlyMemory<TSource> source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                int index;

                internal Enumerator(in MemoryWhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source.Span;
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

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                int index;

                internal DisposableEnumerator(in MemoryWhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = -1;
                }

                [MaybeNull] 
                public readonly TResult Current 
                    => selector(source.Span[index]);
                readonly object? IEnumerator.Current 
                    => selector(source.Span[index]);

                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index < source.Length)
                    {
                        if (predicate(span[index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() { }                
            }

            public int Count()
                => Array.Count<TSource>(source.Span, predicate);

            public bool Any()
                => Array.Any<TSource>(source.Span, predicate);
                
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => Array.Contains<TSource, TResult>(source.Span, value, comparer, predicate, selector);

            public TResult ElementAt(int index)
                => Array.ElementAt<TSource, TResult>(source.Span, index, predicate, selector);

            [return: MaybeNull]
            public TResult ElementAtOrDefault(int index)
                => Array.ElementAtOrDefault<TSource, TResult>(source.Span, index, predicate, selector);

            public TResult First()
                => Array.First<TSource, TResult>(source.Span, predicate, selector);

            [return: MaybeNull]
            public TResult FirstOrDefault()
                => Array.FirstOrDefault<TSource, TResult>(source.Span, predicate, selector);

            public TResult Single()
                => Array.Single<TSource, TResult>(source.Span, predicate, selector);

            [return: MaybeNull]
            public TResult SingleOrDefault()
                => Array.SingleOrDefault<TSource, TResult>(source.Span, predicate, selector);

            public TResult[] ToArray()
                => Array.ToArray<TSource, TResult>(source.Span, predicate, selector);

            public List<TResult> ToList()
                => Array.ToList<TSource, TResult>(source, predicate, selector); // memory performs best

            public void ForEach(Action<TResult> action)
                => source.Span.ForEach(action, predicate, selector);
            public void ForEach(ActionAt<TResult> action)
                => source.Span.ForEach(action, predicate, selector);
        }
    }
}

