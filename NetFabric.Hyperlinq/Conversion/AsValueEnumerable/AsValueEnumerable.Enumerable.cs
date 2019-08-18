using System;
using System.Collections;
using System.Collections.Generic;
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
            where TEnumerator : struct, IEnumerator<TSource>
            => new ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source, getEnumerator);

        [GenericsTypeMapping("TEnumerable", typeof(ValueEnumerableWrapper<,,>))]
        public readonly struct ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, TEnumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TEnumerable, TEnumerator> getEnumerator;

            internal ValueEnumerableWrapper(TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            {
                this.source = source;
                this.getEnumerator = getEnumerator;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator GetEnumerator() => getEnumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => getEnumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => getEnumerator(source);
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
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                IEnumerator<TSource> enumerator;

                internal Enumerator(IEnumerable<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                public TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                object IEnumerator.Current 
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => enumerator.MoveNext();

                readonly void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}
