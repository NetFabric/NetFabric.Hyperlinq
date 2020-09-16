using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source);

        public readonly partial struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal DistinctEnumerable(TEnumerable source)
                => this.source = source;

            public readonly Enumerator GetEnumerator()
                => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator>.GetEnumerator()
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

