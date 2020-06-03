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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryDistinctEnumerable<TSource> Distinct<TSource>(
            this ReadOnlyMemory<TSource> source, 
            IEqualityComparer<TSource>? comparer = null)
            => new MemoryDistinctEnumerable<TSource>(source, comparer);

        public readonly partial struct MemoryDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, MemoryDistinctEnumerable<TSource>.DisposableEnumerator>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal MemoryDistinctEnumerable(ReadOnlyMemory<TSource> source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, MemoryDistinctEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly HashSet<TSource> set;
                int index;

                internal Enumerator(in MemoryDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Span;
                    set = new HashSet<TSource>(enumerable.comparer);
                    index = -1;
                    Current = default!;
                }

                [MaybeNull]
                public TSource Current { get; private set; }

                public bool MoveNext()
                {
                    while (++index < source.Length)
                    {
                        if (set.Add(source[index]))
                        {
                            Current = source[index];
                            return true;
                        }
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                readonly HashSet<TSource> set;
                int index;

                internal DisposableEnumerator(in MemoryDistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    index = -1;
                    Current = default!;
                }

                [MaybeNull]
#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
                public TSource Current { get; private set; }
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
                readonly object? IEnumerator.Current 
                    => Current;

                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index < source.Length)
                    {
                        if (set.Add(span[index]))
                        {
                            Current = span[index];
                            return true;
                        }
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            // helper function for optimization of non-lazy operations
            readonly HashSet<TSource> FillSet() 
            {
                var set = new HashSet<TSource>(comparer);
                var span = source.Span;
                for (var index = 0; index < source.Length; index++)
                    _ = set.Add(span[index]);
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => HashSetBindings.ToArray<TSource>(FillSet());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => HashSetBindings.ToList<TSource>(FillSet());

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
            {
                comparer ??= EqualityComparer<TSource>.Default;

                var enumerator = GetEnumerator();
                using var otherEnumerator = other.GetEnumerator();
                while (true)
                {
                    var thisEnded = !enumerator.MoveNext();
                    var otherEnded = !otherEnumerator.MoveNext();

                    if (thisEnded != otherEnded)
                        return false;

                    if (thisEnded)
                        return true;

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

