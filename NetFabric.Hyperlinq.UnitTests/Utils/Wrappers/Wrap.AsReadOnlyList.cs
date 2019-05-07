using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ReadOnlyList<T> AsReadOnlyList<T>(T[] source)
            => new ReadOnlyList<T>(source);

        public struct ReadOnlyList<T> 
            : IReadOnlyList<T>
        {
            readonly T[] source;

            internal ReadOnlyList(T[] source)
            {
                this.source = source;
            }

            public int Count => source.Length;

            public T this[int index] => source[index];

            public Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public struct Enumerator 
                : IEnumerator<T>
            {
                readonly T[] source;
                int index;

                internal Enumerator(T[] source)
                {
                    this.source = source;
                    index = -1;
                }

                public T Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext() => ++index < source.Length;
                public void Reset() { index = -1; }
                public void Dispose() { }
            }
        }
    }
}