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
        public static DistinctEnumerable<TSource> Distinct<TSource>(
            this ReadOnlyMemory<TSource> source, 
            IEqualityComparer<TSource>? comparer = null)
            => new DistinctEnumerable<TSource>(source, comparer);

        public readonly partial struct DistinctEnumerable<TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TSource>.DisposableEnumerator>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly IEqualityComparer<TSource>? comparer;

            internal DistinctEnumerable(ReadOnlyMemory<TSource> source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DistinctEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly HashSet<TSource> set;
                int index;
                TSource current;

                internal Enumerator(in DistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Span;
                    set = new HashSet<TSource>(enumerable.comparer);
                    index = -1;
                    current = default!;
                }

                [MaybeNull]
                public readonly TSource Current
                    => current;

                public bool MoveNext()
                {
                    while (++index < source.Length)
                    {
                        if (set.Add(source[index]))
                        {
                            current = source[index];
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
                TSource current;

                internal DisposableEnumerator(in DistinctEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    set = new HashSet<TSource>(enumerable.comparer);
                    index = -1;
                    current = default!;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => current;
                readonly object? IEnumerator.Current 
                    => current;

                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index < source.Length)
                    {
                        if (set.Add(span[index]))
                        {
                            current = span[index];
                            return true;
                        }
                    }
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

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
            public readonly long LongCount()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => FillSet().Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => HashSetBindings.ToArray<TSource>(FillSet());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => HashSetBindings.ToList<TSource>(FillSet());
        }
    }
}

