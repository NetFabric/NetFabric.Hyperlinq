using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this IEnumerable<TSource> source)
            => new ValueEnumerableWrapper<TSource>(source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source, getEnumerator);

        [GenericsTypeMapping("TEnumerable", typeof(ValueEnumerableWrapper<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(ValueEnumerableWrapper<,,>.Enumerator))]
        public readonly struct ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TEnumerable, TEnumerator> getEnumerator;

            internal ValueEnumerableWrapper(TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            {
                this.source = source;
                this.getEnumerator = getEnumerator;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator()
            {
                var enumerator = getEnumerator(source);
                return new Enumerator(in enumerator);
            }
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => getEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => getEnumerator(source);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly

                internal Enumerator(in TEnumerator enumerator)
                {
                    this.enumerator = enumerator;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }
        }

        [GenericsTypeMapping("TEnumerable", typeof(ValueEnumerableWrapper<>))]
        [GenericsTypeMapping("TEnumerator", typeof(ValueEnumerableWrapper<>.Enumerator))]
        public readonly struct ValueEnumerableWrapper<TSource>
            : IValueEnumerable<TSource, ValueEnumerableWrapper<TSource>.Enumerator>
        {
            readonly IEnumerable<TSource> source;

            internal ValueEnumerableWrapper(IEnumerable<TSource> source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            public readonly struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;

                internal Enumerator(IEnumerable<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => enumerator.MoveNext();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}
