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
        public static MemoryValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this ReadOnlyMemory<TSource> source)
            => new MemoryValueEnumerableWrapper<TSource>(source);

        public readonly partial struct MemoryValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, MemoryValueEnumerableWrapper<TSource>.DisposableEnumerator>
        {
            readonly ReadOnlyMemory<TSource> source;

            internal MemoryValueEnumerableWrapper(ReadOnlyMemory<TSource> source) 
                => this.source = source;

            [Pure]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(source);
            readonly DisposableEnumerator IValueEnumerable<TSource, MemoryValueEnumerableWrapper<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(source);

            public readonly int Count => source.Length;

            [MaybeNull]
            public readonly ref readonly TSource this[int index] 
                => ref source.Span[index];
            [MaybeNull]
            readonly TSource IReadOnlyList<TSource>.this[int index] 
                => source.Span[index];

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                int index;

                internal Enumerator(ReadOnlyMemory<TSource> source)
                {
                    this.source = source.Span;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < source.Length;
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                int index;

                internal DisposableEnumerator(ReadOnlyMemory<TSource> source)
                {
                    this.source = source;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current 
                    => ref source.Span[index];
                [MaybeNull]
                readonly TSource IEnumerator<TSource>.Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current 
                    => source.Span[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < source.Length;

                public void Reset() => index = -1;

                public readonly void Dispose() { }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.Span.ToArray();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => Array.ToList<TSource>(source.Span);
        }

        public static int Count<TSource>(this MemoryValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}