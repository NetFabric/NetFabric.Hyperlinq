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
        public static ArrayValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => new ArrayValueEnumerableWrapper<TSource>(source);

        public readonly partial struct ArrayValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, ArrayValueEnumerableWrapper<TSource>.DisposableEnumerator>
        {
            readonly TSource[] source;

            internal ArrayValueEnumerableWrapper(TSource[] source) 
                => this.source = source;

            [Pure]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(source);
            readonly DisposableEnumerator IValueEnumerable<TSource, ArrayValueEnumerableWrapper<TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(source);

            public readonly int Count => source.Length;

            [MaybeNull]
            public readonly ref readonly TSource this[int index] 
                => ref source[index];
            [MaybeNull]
            readonly TSource IReadOnlyList<TSource>.this[int index] 
                => source[index];

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
                    => ref source[index];

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
                    => ref source[index];
                [MaybeNull]
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < source.Length;

                public void Reset() => index = -1;

                public readonly void Dispose() { }
            }
        }

        public static int Count<TSource>(this ArrayValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}