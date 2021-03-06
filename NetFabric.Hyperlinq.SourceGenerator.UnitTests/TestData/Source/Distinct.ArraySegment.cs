﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this in ArraySegment<TSource> source)
            => new(source);

        public readonly partial struct ArraySegmentDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, ArraySegmentDistinctEnumerable<TSource>.DisposableEnumerator>
        {
            readonly ArraySegment<TSource> source;

            internal ArraySegmentDistinctEnumerable(in ArraySegment<TSource> source)
                => this.source = source;

            public Enumerator GetEnumerator()
                => new();

            DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator()
                => new();

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator();

            IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator();

            public struct Enumerator
            {
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                public readonly TSource Current => default!;
                readonly TSource IEnumerator<TSource>.Current => default!;
                readonly object IEnumerator.Current => default!;

                public bool MoveNext()
                    => false;

                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}

