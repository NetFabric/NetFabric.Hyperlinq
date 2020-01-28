using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => new ValueEnumerableWrapper<TSource>(source);

        public readonly partial struct ValueEnumerableWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueEnumerableWrapper<TSource>.Enumerator>
        {
            readonly IReadOnlyList<TSource> source;

            internal ValueEnumerableWrapper(IReadOnlyList<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TSource this[int index]
                => source[index];

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly IReadOnlyList<TSource> source;
                int index;

                internal Enumerator(IReadOnlyList<TSource> source) 
                {
                    this.source = source;
                    index = -1;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < source.Count;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public void Reset() 
                    => index = -1;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Dispose() { }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyList.ToArray<IReadOnlyList<TSource>, TSource>(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyList.ToList<IReadOnlyList<TSource>, TSource>(source);
        }

        public static int Count<TSource>(this ValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}