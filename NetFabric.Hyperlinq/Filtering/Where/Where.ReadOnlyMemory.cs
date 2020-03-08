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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource> Where<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new MemoryWhereEnumerable<TSource>(source, predicate);
        }

        public readonly partial struct MemoryWhereEnumerable<TSource>
            : IValueEnumerable<TSource, MemoryWhereEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal MemoryWhereEnumerable(in ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, MemoryWhereEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public ref struct Enumerator 
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Predicate<TSource> predicate;
                int index;

                internal Enumerator(in MemoryWhereEnumerable<TSource> enumerable)
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

                internal DisposableEnumerator(in MemoryWhereEnumerable<TSource> enumerable)
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
                
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => Array.Contains<TSource>(source.Span, value, comparer, predicate);

            public MemoryWhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public MemoryWhereIndexEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public MemoryWhereSelectEnumerable<TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => Array.WhereSelect<TSource, TResult>(source, predicate, selector);

            public ref readonly TSource ElementAt(int index)
                => ref Array.ElementAt(source.Span, index, predicate);

            [return: MaybeNull]
            public ref readonly TSource ElementAtOrDefault(int index)
                => ref Array.ElementAtOrDefault(source.Span, index, predicate);

            public ref readonly TSource First()
                => ref Array.First(source.Span, predicate);

            [return: MaybeNull]
            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault(source.Span, predicate);

            public ref readonly TSource Single()
                => ref Array.Single(source.Span, predicate);

            [return: MaybeNull]
            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault(source.Span, predicate);

            public TSource[] ToArray()
                => Array.ToArray<TSource>(source.Span, predicate);

            public List<TSource> ToList()
                => Array.ToList<TSource>(source, predicate); // memory performs best

            public void ForEach(Action<TSource> action)
                => Array.ForEach<TSource>(source.Span, action, predicate);
            public void ForEach(ActionAt<TSource> action)
                => Array.ForEach<TSource>(source.Span, action, predicate);
        }
    }
}

