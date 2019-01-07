using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            new EmptyEnumerable<TSource>();

        public readonly struct EmptyEnumerable<TSource> : IEnumerable<TSource>
        {
            public Enumerator GetEnumerator() => new Enumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator();
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator();

            public readonly struct Enumerator : IEnumerator<TSource>
            {
                public TSource Current => default;
                object IEnumerator.Current => default;

                public bool MoveNext() => false;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}

