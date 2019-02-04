using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            new EmptyEnumerable<TSource>();

        public readonly struct EmptyEnumerable<TSource> : IReadOnlyList<TSource>
        {
            public Enumerator GetEnumerator() => new Enumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator();
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator();

            public int Count => 0;

            public TSource this[int index] => throw new IndexOutOfRangeException();

            public readonly struct Enumerator : IEnumerator<TSource>
            {
                public TSource Current => default;
                object IEnumerator.Current => default;

                public bool MoveNext() => false;

                public void Reset() { }

                public void Dispose() { }
            }
        }
    }
}

