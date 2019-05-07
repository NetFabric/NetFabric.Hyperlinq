using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyList<T> AsValueReadOnlyList<T>(T[] source)
            => new ValueReadOnlyList<T>(source);

        public struct ValueReadOnlyList<T> 
            : IValueReadOnlyList<T, ValueReadOnlyList<T>.Enumerator>
        {
            readonly T[] source;

            internal ValueReadOnlyList(T[] source)
            {
                this.source = source;
            }

            public long Count => source.Length;

            public T this[int index] => source[index];
            T IValueReadOnlyList<T, ValueReadOnlyList<T>.Enumerator>.this[long index] => source[(int)index];

            public Enumerator GetValueEnumerator() => new Enumerator(source);

            public struct Enumerator 
                : IValueEnumerator<T>
            {
                readonly T[] source;
                int index;

                internal Enumerator(T[] source)
                {
                    this.source = source;
                    index = -1;
                }

                public bool TryMoveNext(out T current)
                {
                    if (++index < source.Length)
                    {
                        current = source[index];
                        return true;
                    }
                    
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++index < source.Length;

                public void Dispose() { }
            }
        }
    }
}