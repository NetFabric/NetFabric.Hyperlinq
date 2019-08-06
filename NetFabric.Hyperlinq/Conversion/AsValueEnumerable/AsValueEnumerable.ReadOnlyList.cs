using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerableEnumerable<TSource> AsValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
           => new AsValueEnumerableEnumerable<TSource>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerableEnumerable<IReadOnlyList<TSource>, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this IReadOnlyList<TSource> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => new AsValueEnumerableEnumerable<IReadOnlyList<TSource>, TEnumerator, TSource>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            => new AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);

        [GenericsTypeMapping("TEnumerable", typeof(AsValueEnumerableEnumerable<,,>))]
        public readonly struct AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsValueEnumerableEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TEnumerator GetEnumerator() => (TEnumerator)source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public TSource this[int index] => source[index];
        }

        [GenericsTypeMapping("TEnumerable", typeof(AsValueEnumerableEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsValueEnumerableEnumerable<>.Enumerator))]
        public readonly struct AsValueEnumerableEnumerable<TSource>
            : IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TSource>.Enumerator>
        {
            readonly IReadOnlyList<TSource> source;

            internal AsValueEnumerableEnumerable(IReadOnlyList<TSource> source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public TSource this[int index] => source[index];

            public struct Enumerator
                : IEnumerator<TSource>
            {
                IEnumerator<TSource> enumerator;

                internal Enumerator(IReadOnlyList<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                public TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                object IEnumerator.Current => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => enumerator.MoveNext();

                void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}
