﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static AsValueEnumerableEnumerable<TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => new AsValueEnumerableEnumerable<TSource>(source);

        [GenericsTypeMapping("TEnumerable", typeof(AsValueEnumerableEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsValueEnumerableEnumerable<>.Enumerator))]
        public readonly struct AsValueEnumerableEnumerable<TSource>
            : IValueReadOnlyList<TSource, AsValueEnumerableEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;

            internal AsValueEnumerableEnumerable(TSource[] source)
            {
                this.source = source;
            }

            public Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public int Count => source.Length;

            public ref TSource this[int index] => ref source[index];
            TSource IReadOnlyList<TSource>.this[int index] => source[index];

            public struct Enumerator 
                : IEnumerator<TSource>
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

                public ref TSource Current => ref source[index];
                TSource IEnumerator<TSource>.Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext() => ++index < count;

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}
