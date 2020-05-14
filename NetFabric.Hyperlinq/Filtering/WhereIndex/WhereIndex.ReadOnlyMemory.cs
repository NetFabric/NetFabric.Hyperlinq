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
        public static MemoryWhereIndexEnumerable<TSource> Where<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new MemoryWhereIndexEnumerable<TSource>(source, predicate);
        }

        public readonly partial struct MemoryWhereIndexEnumerable<TSource>
            : IValueEnumerable<TSource, MemoryWhereIndexEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly PredicateAt<TSource> predicate;

            internal MemoryWhereIndexEnumerable(in ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, MemoryWhereIndexEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public ref struct Enumerator 
            {
                readonly ReadOnlySpan<TSource> source;
                readonly PredicateAt<TSource> predicate;
                int index;

                internal Enumerator(in MemoryWhereIndexEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Span;
                    predicate = enumerable.predicate;
                    index = -1;
                }

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

                internal DisposableEnumerator(in MemoryWhereIndexEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                }

                public readonly TSource Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current 
                    => source.Span[index];

                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index < source.Length)
                    {
                        if (predicate(span[index], index))
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
                => source.Span.Count(predicate);

            public bool Any()
                => source.Span.Any(predicate);
                
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => source.Span.Contains(value, comparer, predicate);

            public MemoryWhereIndexEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public MemoryWhereIndexEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => Array.ElementAt<TSource>(source.Span, index, predicate);

            public Option<TSource> First()
                => Array.First<TSource>(source.Span, predicate);

            public Option<TSource> Single()
                => Array.Single<TSource>(source.Span, predicate);

            public TSource[] ToArray()
                => Array.ToArray(source.Span, predicate);

            public List<TSource> ToList()
                => Array.ToList(source, predicate);  // memory performs best
        }
    }
}

