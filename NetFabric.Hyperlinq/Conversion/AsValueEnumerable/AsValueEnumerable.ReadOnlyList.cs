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
        public static ValueEnumerableWrapper<TList, TSource> AsValueEnumerable<TList, TSource>(this TList source)
            where TList : notnull, IReadOnlyList<TSource>
            => new ValueEnumerableWrapper<TList, TSource>(source);

        public readonly partial struct ValueEnumerableWrapper<TList, TSource>
            : IValueReadOnlyList<TSource, ValueEnumerableWrapper<TList, TSource>.Enumerator>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;

            internal ValueEnumerableWrapper(in TList source) 
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
                readonly TList source;
                int index;

                internal Enumerator(in TList source) 
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
                => ReadOnlyList.ToArray<TList, TSource>(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyList.ToList<TList, TSource>(source);
        }

        public static int Count<TList, TSource>(this ValueEnumerableWrapper<TList, TSource> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}