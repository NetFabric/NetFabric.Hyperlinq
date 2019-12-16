using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => new ValueEnumerableWrapper<TSource>(source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            => new ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source, getEnumerator);

        [GenericsTypeMapping("TEnumerable", typeof(ValueEnumerableWrapper<,,>))]
        public readonly struct ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TEnumerable, TEnumerator> getEnumerator;

            internal ValueEnumerableWrapper(TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            {
                this.source = source;
                this.getEnumerator = getEnumerator;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator GetEnumerator() => getEnumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => getEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => getEnumerator(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyCollection.ToArray(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyCollection.ToList(source);
        }

        [GenericsTypeMapping("TEnumerable", typeof(ValueEnumerableWrapper<>))]
        [GenericsTypeMapping("TEnumerator", typeof(ValueEnumerableWrapper<>.Enumerator))]
        public readonly struct ValueEnumerableWrapper<TSource>
            : IValueReadOnlyCollection<TSource, ValueEnumerableWrapper<TSource>.Enumerator>
        {
            readonly IReadOnlyCollection<TSource> source;

            internal ValueEnumerableWrapper(IReadOnlyCollection<TSource> source)
            {
                this.source = source;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public readonly struct Enumerator
                : IEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;

                internal Enumerator(IReadOnlyCollection<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly object? IEnumerator.Current => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() => enumerator.MoveNext();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Reset() => enumerator.Reset();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Dispose() => enumerator.Dispose();
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyCollection.ToArray(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyCollection.ToList(source);
        }
    }
}