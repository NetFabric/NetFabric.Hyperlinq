using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this in ArraySegment<TSource> source)
            => new ArraySegmentDistinctEnumerable<TSource>(source);

        public readonly partial struct ArraySegmentDistinctEnumerable<TSource>
            : IValueEnumerable<TSource, ArraySegmentDistinctEnumerable<TSource>.DisposableEnumerator>
        {
            readonly ArraySegment<TSource> source;

            internal ArraySegmentDistinctEnumerable(in ArraySegment<TSource> source)
                => this.source = source;

            public readonly Enumerator GetEnumerator()
                => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TSource, ArraySegmentDistinctEnumerable<TSource>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator();

            public struct Enumerator
            {
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                public readonly TSource Current => default!;
                readonly TSource IEnumerator<TSource>.Current => default!;
                readonly object? IEnumerator.Current => default;

                public bool MoveNext()
                    => false;

                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}

