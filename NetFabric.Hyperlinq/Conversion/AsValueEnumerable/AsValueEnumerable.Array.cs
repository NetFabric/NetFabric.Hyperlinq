using System;
using System.Collections;
using System.Collections.Generic;
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

        public readonly struct ValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueEnumerableWrapper<TSource>.Enumerator>
        {
            readonly TSource[] source;

            internal ValueEnumerableWrapper(TSource[] source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => ValueEnumerator.ToEnumerator<TSource, Enumerator>(new Enumerator(source));
            readonly IEnumerator IEnumerable.GetEnumerator() => ValueEnumerator.ToEnumerator<TSource, Enumerator>(new Enumerator(source));

            public readonly int Count => source.Length;

            public readonly ref readonly TSource this[int index] => ref source[index];
            readonly TSource IReadOnlyList<TSource>.this[int index] => source[index];

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly int count;
                int index;

                internal Enumerator(TSource[] source)
                {
                    this.source = source;
                    count = source.Length;
                    index = -1;
                }

                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }
                readonly TSource IValueEnumerator<TSource>.Current => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < count;
            }
        }
    }
}
