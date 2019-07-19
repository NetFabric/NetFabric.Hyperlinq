using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyCollection<T> AsValueReadOnlyCollection<T>(T[] source)
            => new ValueReadOnlyCollection<T>(source);

        public struct ValueReadOnlyCollection<T> 
            : IValueReadOnlyCollection<T, ValueReadOnlyCollection<T>.Enumerator>
        {
            readonly T[] source;

            internal ValueReadOnlyCollection(T[] source)
            {
                this.source = source;
            }

            public int Count => source.Length;

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

                public T Current
                    => source[index];
                object IEnumerator.Current
                    => source[index];

                public bool MoveNext()
                    => ++index < source.Length;

                public void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}