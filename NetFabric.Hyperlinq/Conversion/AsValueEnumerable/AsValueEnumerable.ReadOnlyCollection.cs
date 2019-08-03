using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerableEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
           => new AsValueEnumerableEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>(source);

        [GenericsTypeMapping("TEnumerable", typeof(AsValueEnumerableEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsValueEnumerableEnumerable<,,>.Enumerator))]
        public readonly struct AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsValueEnumerableEnumerable(in TEnumerable source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() => new Enumerator(in source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in source);

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }
            
            public struct Enumerator 
                : IEnumerator<TSource>
            {
                TEnumerator enumerator;

                internal Enumerator(in TEnumerable enumerable)
                {
                    enumerator = (TEnumerator)enumerable.GetEnumerator();
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
