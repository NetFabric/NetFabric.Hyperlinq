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
        public static ValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => new ValueEnumerableWrapper<TSource>(source);

        public readonly partial struct ValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueEnumerableWrapper<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;

            internal ValueEnumerableWrapper(TSource[] source) 
                => this.source = source;

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            readonly DisposableEnumerator IValueEnumerable<TSource, ValueEnumerableWrapper<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(source);

            public readonly int Count => source.Length;

            public readonly ref readonly TSource this[int index] => ref source[index];
            readonly TSource IReadOnlyList<TSource>.this[int index] => source[index];

            public struct Enumerator
            {
                readonly TSource[] source;
                int index;

                internal Enumerator(TSource[] source)
                {
                    this.source = source;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < source.Length;
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                int index;

                internal DisposableEnumerator(TSource[] source)
                {
                    this.source = source;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }
                [MaybeNull]
                readonly TSource IEnumerator<TSource>.Current => source[index];
                readonly object? IEnumerator.Current => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < source.Length;

                public void Reset() => index = -1;

                public readonly void Dispose() { }
            }
        }

        public static int Count<TSource>(this ValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}